KinoSLog3
=========

![screenshot](https://i.imgur.com/D0OWCe0.png)
![screenshot](https://i.imgur.com/cJjhT8d.png)

**KinoSLog3** is a post-processing effect for [Unity HDRP] that applies the
[S-Log3] gamma curve to rendered frames. It's not a sophisticated way to handle
HDR renders (you should use proper industry standards) but makes it possible to
grade with a wider dynamic range in an external editing tool.

[Unity HDRP]: https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@latest/
[S-Log3]: https://pro.sony/en_BE/technology/s-log

![gif](https://i.imgur.com/uwEJ21r.gif)

TIPS
----

- HDRP applies the ACES tonemapper by default. You should disable it when using
  a log gamma.
- The bloom effect in the post-processing effect is very prone to introduce
  banding in dark areas. It'd recommended to use a glow effect with external
  software instead.
