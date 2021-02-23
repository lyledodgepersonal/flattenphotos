# Overview

iTunes doesn't like nested directories for photo sharing to AppleTV, so I created this project to make it easy to take an input folder (I filter by jpg, jpeg, png) and flatten it (directory-[subdirectories]-filename) into one folder, so that you can sign in to iTunes, turn on home sharing, then pick the destination folder.

It just checks for existence or not, and copies sources over, not any file modifications.

Usage: flattenphotos "source directory" "destination directory"