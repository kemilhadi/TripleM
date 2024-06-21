import qrcode 

qr = qrcode.make("hello")
qr.save("qr.png")