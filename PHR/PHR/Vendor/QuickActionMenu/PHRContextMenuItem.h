//
//  M13ContextMenuItemIOS7.h
//  M13ContextMenu
//
/*Copyright (c) 2014 Brandon McQuilkin
 
 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

#import "PHRContextMenu.h"

@interface PHRContextMenuItem : ContextMenuItem

/**@name Initalization*/
/**
Initalize a menu item with the given icons.

@param unselected The icon to display when the menu item is unselected.
@param selected   The icon to display when the menu item is selected.

@return A new menu item.
*/
- (id)initWithUnselectedIcon:(UIImage *)unselected selectedIcon:(UIImage *)selected;
/**
 The tint color of the item.
 */
@property (nonatomic, retain) UIColor *tintColor;
@property (nonatomic, retain) UIColor *highlightedTintColor;

@end
