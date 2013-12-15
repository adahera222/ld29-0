#!/usr/bin/env python
import sys
import pygame

def main(argv):
    path = 'out.png'
    color = 'red'
    (w,h) = (100,40)
    p = 8
    img = pygame.Surface((w,h), pygame.SRCALPHA, 32)
    x0 = w-h
    pts = [(0,h/2-p), (x0,h/2-p), (x0,0), (w,h/2), (x0,h), (x0,h/2+p), (0,h/2+p)]
    pygame.draw.polygon(img, pygame.Color(color), pts)
    pygame.image.save(img, path)
    return 0

if __name__ == '__main__': sys.exit(main(sys.argv))
