.PHONY: all install pdfs clean

WORKSPACE := /workspace
VENV := $(WORKSPACE)/.venv
PY := $(VENV)/bin/python
PIP := $(VENV)/bin/pip

all: pdfs

install:
	@if [ ! -d "$(VENV)" ] || [ ! -x "$(PIP)" ]; then \
		python3 -m pip install --user --upgrade virtualenv || true; \
		python3 -m virtualenv "$(VENV)" || virtualenv "$(VENV)" || true; \
	fi
	@if [ -x "$(PIP)" ]; then \
		"$(PIP)" install --upgrade pip && \
		"$(PIP)" install -r "$(WORKSPACE)/requirements.txt"; \
	else \
		python3 -m pip install --upgrade pip --break-system-packages && \
		python3 -m pip install -r "$(WORKSPACE)/requirements.txt" --break-system-packages; \
	fi

pdfs: install
	@if [ -x "$(PY)" ]; then \
		"$(PY)" "$(WORKSPACE)/scripts/generate_pdfs.py" "$(WORKSPACE)/docs"; \
	else \
		python3 "$(WORKSPACE)/scripts/generate_pdfs.py" "$(WORKSPACE)/docs"; \
	fi

clean:
	rm -f $(WORKSPACE)/docs/*.pdf
