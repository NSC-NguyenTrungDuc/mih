//
//  PHRButtonComboboxNoLine.h
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "IQActionSheetPickerView.h"

@protocol PHRButtonComboboxNoLineDelegate <NSObject>
- (void)didSelectItem;
@end

@interface PHRButtonComboboxNoLine : UITextField {
    
}
@property (nonatomic, strong) UIImageView *imageArrow;
- (void)setClickEnable:(BOOL)enable;
- (void)setArrayChoices:(NSArray *)arrayChoices;
@property (copy, nonatomic) void(^onTextChange)(NSString* text);
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectTitles:(NSArray *)titles;
- (void)onClicked;
@property (nonatomic, weak) id<PHRButtonComboboxNoLineDelegate> delegateSelectItem;
@end
