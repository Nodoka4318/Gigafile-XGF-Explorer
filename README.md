# XGF-Explorer
## Disclaimer
| This software is **for educational purposes only**. |
| --------------------------------------------------- |
| The author **assumes no responsibility** for any problems with this software. |

## Overview
This software randomly generates 4-digit codes for [xgf.nu](https://xgf.nu), a URL shortening service for [Gigafile](https://gigafile.nu), and searches uploaded files.

## Functions
- Automatic checking of valid codes
- Prevention of duplicate codes
- Downloading of one or multiple files found
- Saving search logs

## How to use
Download the latest version zip from the release page and unzip it.

## Screenshots

# Conclusion
The 4-digit code in xgf.nu uses only single-byte alphanumeric characters.
Therefore, when you enter the code at random, the probability of your file being accessed is
$$(\frac{1}{62})^4 = \frac{1}{14776336}.$$ \
It is small, but when you run brute force with a computer, the probability increases greatly because you can search thousands of files in a short period of time.

To prevent the leakage of your data, you should

- Set download passwords
- Do not shorten links
- Avoid using Gigafile when sending important data.

<big>**Be careful with your important files!**</big>
