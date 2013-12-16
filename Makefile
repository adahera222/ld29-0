# Makefile

RM=rm -f
CP=cp -f
RSYNC=rsync -av

# Project settings
TARGET=rube
URLBASE=ludumdare.tabesugi.net:public/file/ludumdare.tabesugi.net/$(TARGET)

all: 

update: build
	cd build && mv build.html index.html
	$(RSYNC) build/ $(URLBASE)/
