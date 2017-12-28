//
//  PHRButtonComboboxNoLine.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRButtonComboboxNoLine.h"
#import "IQActionSheetPickerView.h"
#import <PureLayout/PureLayout.h>

@interface PHRButtonComboboxNoLine () <IQActionSheetPickerViewDelegate>{
    
}

@property (nonatomic, strong) NSArray *arrayChoices;


@end

@implementation PHRButtonComboboxNoLine

- (id)initWithCoder:(NSCoder *)aDecoder {
    self = [super initWithCoder:aDecoder];
    [self createContentControl];
    return self;
}

- (void)createContentControl {
    [self setBackgroundColor:[UIColor clearColor]];
    
    // Icon arrow
    self.imageArrow = [[UIImageView alloc] initForAutoLayout];
    [self.imageArrow setImage:[UIImage imageNamed:@"Icon_Arrow_Down"]];
    [self.imageArrow setContentMode:UIViewContentModeCenter];
    [self addSubview:self.imageArrow];
    [self.imageArrow autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:30];
    [self.imageArrow autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:(self.bounds.size.height / 2 - self.imageArrow.bounds.size.height - 3)];
    [self.imageArrow autoMatchDimension:ALDimensionWidth toDimension:ALDimensionHeight ofView:self.imageArrow];
    
    // Label
    //    self.labelTitle = [[UILabel alloc] initForAutoLayout];
    //    [self setFont:[FontUtils aileronRegularWithSize:12]];
    [self setTextColor:[UIColor whiteColor]];
    
    //[self addSubview:self.labelTitle];
    // [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:10];
    // [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:10];
    
    UIButton *button = [[UIButton alloc] initForAutoLayout];
    [button setBackgroundColor:[UIColor clearColor]];
    [self addSubview:button];
    [button autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [button autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [button autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
    [button autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    // [self.labelTitle setHidden:true];
    // Click
    [button addTarget:self action:@selector(onClicked) forControlEvents:UIControlEventTouchUpInside];
}

- (void)setClickEnable:(BOOL)enable {
    [self setEnabled:enable];
}

- (void)setArrayChoices:(NSArray *)arrayChoices {
    _arrayChoices = arrayChoices;
    if (arrayChoices && arrayChoices.count > 0) {
        [self setPlaceholder:kLocalizedString(kGender)];
    }
    else{
        [self setText:@""];
    }
}

- (CGRect)textRectForBounds:(CGRect)bounds {
    return CGRectInset(bounds, 10, 10);
}

// text position
- (CGRect)editingRectForBounds:(CGRect)bounds {
    return CGRectInset(bounds, 10, 10);
}

/*
 On Clicked
 */
- (void)onClicked {
    // Close keyboard before open date picker
    if ([self superview]) {
        [[self superview] endEditing:YES];
    }
    
    if (!self.arrayChoices) {
        return;
    }
    
    // Date picker
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:kLocalizedString(kGender) delegate:self];
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleTextPicker];
    [picker setTitlesForComponenets:[NSArray arrayWithObject:_arrayChoices]];
    [picker setSelectedTitles:@[self.text]];
    [picker show];
}

#pragma mark - Action sheet delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectTitles:(NSArray *)titles {
    self.onTextChange(titles[0]);
    if (!titles || titles.count <= 0) {
        return;
    }
    [self setText:titles[0]];
    if (self.delegateSelectItem){
        [self.delegateSelectItem didSelectItem];
    }
}

@end
