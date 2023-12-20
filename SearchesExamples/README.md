## Searches:

Linear: Searches sequentially one at a time until it gets to the target value.

Binary: Requires a sorted dataset, starts at the middle and sees if the middle number is higher or lower than the target, then looks at the middle the higher or lower halves until it finds the target.

Interpolation: Similar to Binary, but instead of starting in the middle it can start at different values depending on the target.

Linear is the slowest due to it literally working it's way up the dataset one by one, with no particular algorithm or mindset. Binary and Interpolation are different in that Binary
will always start at the center of the dataset, while Interpolation has the potential to start in different places in the data.