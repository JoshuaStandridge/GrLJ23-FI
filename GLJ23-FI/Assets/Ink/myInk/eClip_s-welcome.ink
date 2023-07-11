VAR godVpaint = 0

-> main

=== main ===
Hiya! #speaker:eClip #portrait:eClip_happy #layout:right
My name is eClip. 
Welcome to the wonderful world of Michaelsoft Arpeture!

 + Why have I been downloaded? #speaker:vRuss #portrait:vRuss_disturb #layout:left
    ~ godVpaint = 1
    The great user in the sky must have meant it to be! #speaker:eClip #portrait:eClip_shook #layout:right
    Hallelujah! #portrait:eClip_happy
    
 + Existence is pain. #speaker:vRuss #portrait:vRuss_disappoint #layout:left
    ~ godVpaint = 2
    ... #speaker:eClip #portrait:eClip_shook #layout:right
    Did you mean to say, "existence is PAINT"? #portrait:eClip_happy

- Hey, that reminds me!
Michaelsoft made a great new app called MS Pigment.
You should give it a try!

{ godVpaint:
- 1: 
-> god
- 2: 
-> paint
- else: error
-> main
}

=== god ===
+ I want to cause destruction. #speaker:vRuss #portrait:vRuss_disturb #layout:left
+ Gods will tremble before me. #speaker:vRuss #portrait:vRuss_disappoint #layout:left
- -> maintwo

=== paint ===
+ I want to cause destruction. #speaker:vRuss #portrait:vRuss_disturb #layout:left
+ I will blot out the sun itself. #speaker:vRuss #portrait:vRuss_disappoint #layout:left
- -> maintwo

=== maintwo ===
... #speaker:eClip #portrait:eClip_shook #layout:right
That's the spirit! #portrait:eClip_happy
You can access MS Pigment from the Go Menu.
Praise Michael!

-> END

