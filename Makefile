# Makefile

RM=rm -f
CP=cp -f
RSYNC=rsync -av

# Project settings
TARGET=foo
URLBASE=ludumdare.tabesugi.net:public/file/ludumdare.tabesugi.net/$(TARGET)

all: 

update: $(TARGET)
	$(RSYNC) $(TARGET)/ $(URLBASE)/
