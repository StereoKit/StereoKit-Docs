---
layout: default
title: Hash
description: This class contains some tools for hashing data within StereoKit! Certain systems in StereoKit use string hashes instead of full strings for faster search and compare, like UI and Materials, so this class gives access to the code SK uses for hashing.  StereoKit currently internally uses a 64 bit FNV hash, though this detail should be pretty transparent to developers.
---
# static class Hash

This class contains some tools for hashing data within
StereoKit! Certain systems in StereoKit use string hashes instead of
full strings for faster search and compare, like UI and Materials, so
this class gives access to the code SK uses for hashing.

StereoKit currently internally uses a 64 bit FNV hash, though this
detail should be pretty transparent to developers.

## Static Methods

|  |  |
|--|--|
|[Int]({{site.url}}/preview/Pages/StereoKit/Hash/Int.html)|This will hash an integer into a hash value that StereoKit can use. This is helpful for adding in some uniqueness using something like a for loop index. This may be best when combined with additional hashes.|
|[String]({{site.url}}/preview/Pages/StereoKit/Hash/String.html)|This will hash the UTF8 representation of the given string into a hash value that StereoKit can use.|
