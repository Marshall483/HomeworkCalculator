open System
open Microsoft.FSharp.Math
open System.Windows.Forms
open System.Drawing

let cMax = complex 1.0 1.0
let cMin = complex -1.0 -1.0

let rec isInMandelbrotSet(z, c, iter, count) = 
    if (cMin < z) && (cMax > z) && (count < iter) then
        isInMandelbrotSet( ((z * z) + c), c, iter, count + 1)
        else count

let scallingFactor s = s * 1.0 / 200.0
let offsetX = -1.0
let offsetY = -1.0

let mapPlane(x, y, s, mx, my) =
    let fx = ((float x) * scallingFactor s) + mx
    let fy = ((float y) * scallingFactor s) + my
    complex fx fy

let colorize c = 
    let r = (4 * c) % 255
    let g = (6 * c) % 255
    let b = (8 * c) % 255
    Color.FromArgb(r, g, b)

let createImage(s, mx, my, iter) = 
    let image = new Bitmap(500,500)
    for x = 0 to image.Width - 1 do 
        for y = 0 to image.Height - 1 do 
            let countIter = isInMandelbrotSet( Complex.Zero, mapPlane(x, y, s, mx, my), iter, 0 )
            if countIter = iter then
                image.SetPixel(x,y, Color.Black)
            else 
                image.SetPixel(x, y, colorize(countIter))
    let temp = new Form() in 
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0,0))
    temp

do Application.Run(createImage(1.5, -1.5, -1.5, 20))
