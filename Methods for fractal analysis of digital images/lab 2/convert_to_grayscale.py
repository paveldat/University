from PIL import Image
import numpy as np


if __name__ == '__main__':
    finished = False
    while not finished:
        print("Please, type the name of the file. Or press enter to skip. Default name is image.jpg\n")
        name = input()
        if not name:
            name = 'image.jpg'
        try:
            im = Image.open(name)
            finished = True
        except Exception as e:
            print(e)
            print("Could not find the file. Please try again.\n")
    
    finished = False
    while not finished:
        print("Please, enter the color: R for Red, G for Green, B for Blue. Or press enter to skip. Default color is Red.\n")
        color = input()
        if not color:
            color = 'R'
        if color in ['R', 'G', 'B']:
            finished = True
        else:
            print("Color is not one of the following: R, G, B. Please try again.\n")
    
    data = im.getdata()
    colors_info = {
        'R': [(d[0], 0, 0) for d in data],
        'G': [(0, d[1], 0) for d in data],
        'B': [(0, 0, d[2]) for d in data]
    }

    im.putdata(colors_info[color])
    im.save('result.png')

