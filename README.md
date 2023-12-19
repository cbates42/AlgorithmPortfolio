# AlgorithmPortfolio

## Big O:

Big-O Notation is really interesting. I've kind of thought of optimization before, but it is really interesting to think of it as Constant, Linear, and Quadratic. I'm interested in working in games, and thinking of ways Linear algorithms could be used is really interesting (like storing randomly generated enemies in a list and pulling them out one at a time etc).

## Fisher-Yates Shuffle:
Fisher-Yates shuffle is an algorithm to randomize data in a way that any element as equal chance to be at any position in the collection. My app loads in data from the Read.txt and shuffles it using the algorithm as I understood it.

## Data Structures:

Array: Collection of elements of the same type that can be accessed by their index. Useful for when you know the number of items won't change. Efficient for reading but not for adding/removing.

Map/Dictionary: Stores data in key-value pairs. Each key is unique and mapped to a value. Useful for when values need to be associated with unique keys and you need to access the items quickly. Efficient for reading.

Stack: Stores data with last-in first-out. Elements can only be added or removed from the top. Useful for things like an undo function. Efficient specifically for removing the latest element or adding a new element but not for accessing other elements and searching.

Queue: Similar to Stack, but stores data with First-in first-out. Elements get added to the end of the line and are removed when they reach the front of the line. Useful when items need to be handled in order, literally like a line. Efficient for specifically adding elements to the end of the line and removing them from the front, not efficient for accessing other elements or searching.

## Searches:

Linear: Searches sequentially one at a time until it gets to the target value.

Binary: Requires a sorted dataset, starts at the middle and sees if the middle number is higher or lower than the target, then looks at the middle the higher or lower halves until it finds the target.

Interpolation: Similar to Binary, but instead of starting in the middle it can start at different values depending on the target.

Linear is the slowest due to it literally working it's way up the dataset one by one, with no particular algorithm or mindset. Binary and Interpolation are different in that Binary
will always start at the center of the dataset, while Interpolation has the potential to start in different places in the data.