# XGF-Explorer
日本語は[コチラ](/README-ja.md)から
## Disclaimer
| THIS SOFTWARE IS **FOR EDUCATIONAL PURPOSES ONLY**. |
| --------------------------------------------------- |
| The author **assumes no responsibility** for any problems with this software. |

## Overview
This software randomly generates 4-digit codes for [xgf.nu](https://xgf.nu), a URL shortening service for [Gigafile](https://gigafile.nu), and searches uploaded files.

## Functions
- Automatic checking of valid codes
- Preventing duplicated codes
- Downloading one or multiple files found
- Saving search logs

**To avoid overloading the requesting server, the frequency of searches is limited to 2 codes per second.**

## How to use
Download the latest version zip from the [release page](https://github.com/Nodoka4318/Gigafile-XGF-Explorer/releases/latest) and unzip it.

## Screenshot
![thumb1](https://user-images.githubusercontent.com/78198198/197372715-efaf1c17-6394-4845-8f41-6af4a31781d3.png)

# Conclusion
The 4-digit code in xgf.nu uses only single-byte alphanumeric characters.
Therefore, when you enter the code at random, the probability of your file being accessed is
$$(\frac{1}{62})^4 = \frac{1}{14776336}.$$ \
It may seem very small, but when you run brute force with a computer, the probability increases greatly because you can search thousands of files in a short period of time.

To prevent the leakage of your data, you should

- Set download passwords
- Do not shorten links
- Avoid using Gigafile when sending important data.

**Be careful with your files!**
