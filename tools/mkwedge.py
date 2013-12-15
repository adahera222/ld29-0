#!/usr/bin/env python
import sys
import pygame

def main(argv):
    path = 'out.png'
    color = '#664400'
    (w,h) = (100,100)
    p = 8
    img = pygame.Surface((w,h), pygame.SRCALPHA, 32)
    x0 = w-h
    pts = [(p,h-p), (w/2, p), (w-p,h-p)]
    pygame.draw.polygon(img, pygame.Color(color), pts)
    pygame.draw.polygon(img, pygame.Color("black"), pts, p)
    pygame.image.save(img, path)
    return 0

if __name__ == '__main__': sys.exit(main(sys.argv))
