//
//  PHRButtonCombobox.h
//  PHR
//
//  Created by Luong Le Hoang on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@protocol PHRButtonComboboxDelegate <NSObject>
- (void)didSelectItem;
@end

@interface PHRButtonCombobox : UIButton{
    
}

- (NSString*)getText;
- (void)setClickEnable:(BOOL)enable;
- (void)setArrayChoices:(NSArray *)arrayChoices;
- (void)setText:(NSString*)text;
- (void)onClicked;
@property (nonatomic, weak) id<PHRButtonComboboxDelegate> delegate;
@end
