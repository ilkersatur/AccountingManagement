#!/usr/bin/env python3
import os
from typing import List, Tuple


def ensure_directory_exists(path: str) -> None:
	os.makedirs(path, exist_ok=True)


def _write_pdf(output_path: str, content_stream: str, mediabox: Tuple[int, int, int, int]=(0, 0, 595, 842)) -> None:
	# Minimal PDF writer with one page, Helvetica font
	# mediabox is (x0, y0, x1, y1) in points (A4 ~ 595x842)
	x0, y0, x1, y1 = mediabox
	objects: List[bytes] = []

	# 1: Catalog
	objects.append(b"<< /Type /Catalog /Pages 2 0 R >>")
	# 2: Pages
	objects.append(b"<< /Type /Pages /Kids [3 0 R] /Count 1 >>")
	# 3: Page
	page_dict = f"<< /Type /Page /Parent 2 0 R /MediaBox [{x0} {y0} {x1} {y1}] /Resources << /Font << /F1 5 0 R >> >> /Contents 4 0 R >>".encode()
	objects.append(page_dict)
	# 4: Contents stream
	stream_bytes = content_stream.encode()
	contents = b"<< /Length " + str(len(stream_bytes)).encode() + b" >>\nstream\n" + stream_bytes + b"\nendstream"
	objects.append(contents)
	# 5: Helvetica Font
	objects.append(b"<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>")

	# Build file
	with open(output_path, "wb") as f:
		f.write(b"%PDF-1.4\n%\xe2\xe3\xcf\xd3\n")
		offsets: List[int] = []
		for i, obj in enumerate(objects, start=1):
			offsets.append(f.tell())
			f.write(f"{i} 0 obj\n".encode())
			f.write(obj)
			f.write(b"\nendobj\n")
		xref_pos = f.tell()
		f.write(f"xref\n0 {len(objects)+1}\n".encode())
		f.write(b"0000000000 65535 f \n")
		for off in offsets:
			f.write(f"{off:010d} 00000 n \n".encode())
		f.write(b"trailer\n")
		f.write(f"<< /Size {len(objects)+1} /Root 1 0 R >>\n".encode())
		f.write(f"startxref\n{xref_pos}\n%%EOF\n".encode())


def _escape_text(text: str) -> str:
	return text.replace("\\", r"\\\\").replace("(", r"\\(").replace(")", r"\\)")


def _text(x: float, y: float, text: str, size: int = 12) -> str:
	escaped = _escape_text(text)
	return f"BT /F1 {size} Tf {x:.2f} {y:.2f} Td ({escaped}) Tj ET\n"


def _rect(x: float, y: float, w: float, h: float, fill: bool=False) -> str:
	cmd = f"{x:.2f} {y:.2f} {w:.2f} {h:.2f} re "
	cmd += "f\n" if fill else "S\n"
	return cmd


def _line(x1: float, y1: float, x2: float, y2: float) -> str:
	return f"{x1:.2f} {y1:.2f} m {x2:.2f} {y2:.2f} l S\n"


def _arrow(x1: float, y1: float, x2: float, y2: float) -> str:
	# Draw line and small triangular head near (x2,y2)
	import math
	cmd = _line(x1, y1, x2, y2)
	angle = math.atan2(y2 - y1, x2 - x1)
	head_len = 8.0
	head_wid = 5.0
	x3 = x2 - head_len * math.cos(angle)
	y3 = y2 - head_len * math.sin(angle)
	xl = x3 + head_wid * math.sin(angle)
	yl = y3 - head_wid * math.cos(angle)
	xr = x3 - head_wid * math.sin(angle)
	yr = y3 + head_wid * math.cos(angle)
	cmd += f"{x2:.2f} {y2:.2f} m {xl:.2f} {yl:.2f} l {xr:.2f} {yr:.2f} l h f\n"
	return cmd


def generate_document(output_path: str) -> None:
	# A4: 595 x 842 points
	content = ""
	content += _text(50, 792, "Project Documentation", 24)
	content += _text(50, 770, "Auto-generated PDF document", 12)
	content += "0.5 w\n"  # stroke width

	body = [
		"This document was generated using a minimal custom PDF writer.",
		"",
		"Contents:",
		"  - Overview",
		"  - Diagram",
		"  - Notes",
		"",
		"Overview:",
		"  This is a sample PDF document created programmatically.",
		"  You can adapt this script to include dynamic content.",
		"",
		"Notes:",
		"  - Font: Helvetica",
		"  - Page size: A4",
		"  - Generated: scripts/generate_pdfs.py",
	]
	y = 740
	for line in body:
		content += _text(50, y, line, 12)
		y -= 16

	# Footer
	content += _text(500, 40, "Generated custom PDF", 9)

	_write_pdf(output_path, content)


def _draw_box_with_label(x: float, y: float, w: float, h: float, label: str) -> str:
	cmd = "0 0 0 RG 0.8 0.8 0.8 rg\n"  # stroke black, fill light gray
	cmd += _rect(x, y, w, h, fill=True)
	cmd += "0 0 0 rg\n"  # reset fill color to black for text
	cmd += _text(x + w/2 - (len(label) * 3), y + h/2 - 4, label, 12)
	return cmd


def generate_diagram(output_path: str) -> None:
	# Landscape A4: swap width/height in mediabox
	width, height = 842, 595
	content = ""
	content += _text(width/2 - 60, height - 30, "Sample Flow Diagram", 14)

	# Boxes
	box_w, box_h = 120, 50
	start_x, start_y = 80, height - 150
	process_x, process_y = 360, height - 150
	end_x, end_y = 240, height - 280

	content += _draw_box_with_label(start_x, start_y, box_w, box_h, "Start")
	content += _draw_box_with_label(process_x, process_y, box_w, box_h, "Process")
	content += _draw_box_with_label(end_x, end_y, box_w, box_h, "End")

	# Connectors
	content += _arrow(start_x + box_w, start_y + box_h/2, process_x, process_y + box_h/2)
	content += _arrow(process_x + box_w/2, process_y, end_x + box_w/2, end_y + box_h)

	_write_pdf(output_path, content, mediabox=(0, 0, width, height))


def main():
	import sys
	if len(sys.argv) > 1:
		out_dir = sys.argv[1]
	else:
		out_dir = os.path.join(os.getcwd(), "docs")
	ensure_directory_exists(out_dir)

	document_pdf = os.path.join(out_dir, "document.pdf")
	diagram_pdf = os.path.join(out_dir, "diagram.pdf")

	generate_document(document_pdf)
	generate_diagram(diagram_pdf)
	print(f"Wrote: {document_pdf}")
	print(f"Wrote: {diagram_pdf}")


if __name__ == "__main__":
	main()

