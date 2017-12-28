//
//  PHRButtonCombobox.m
//  PHR
//
//  Created by Luong Le Hoang on 10/8/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "PHRButtonCombobox.h"
#import "IQActionSheetPickerView.h"
#import <PureLayout/PureLayout.h>

@interface PHRButtonCombobox () <IQActionSheetPickerViewDelegate>{
    
}
@property (nonatomic, strong) UILabel *labelTitle;
@property (nonatomic, strong) NSArray *arrayChoices;

@end

@implementation PHRButtonCombobox

/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */

- (instancetype)initWithFrame:(CGRect)frame{
    self = [super initWithFrame:frame];
    if (self) {
        [self createContentControl];
    }
    return self;
}

- (id)initWithCoder:(NSCoder *)aDecoder {
    self = [super initWithCoder:aDecoder];
    [self createContentControl];
    return self;
}

- (void)createContentControl {
    [self setBackgroundColor:[UIColor clearColor]];
    // Underline
    UIImageView *imageUnderline = [[UIImageView alloc] initForAutoLayout];
    [imageUnderline setBackgroundColor:PHR_COLOR_LINE_GRAY];
    [self addSubview:imageUnderline];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    [imageUnderline autoSetDimension:ALDimensionHeight toSize:1];
    
    // Icon arrow
    UIImageView *imageArrow = [[UIImageView alloc] initForAutoLayout];
    [imageArrow setImage:[UIImage imageNamed:@"ArrowDown"]];
    [imageArrow setContentMode:UIViewContentModeCenter];
    [self addSubview:imageArrow];
    [imageArrow autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [imageArrow autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [imageArrow autoPinEdge:ALEdgeBottom toEdge:ALEdgeTop ofView:imageUnderline];
    [imageArrow autoMatchDimension:ALDimensionWidth toDimension:ALDimensionHeight ofView:imageArrow];
    
    // Icon stand line
    UIImageView *imageStandLine = [[UIImageView alloc] initForAutoLayout];
    [imageStandLine setBackgroundColor:PHR_COLOR_LINE_GRAY];
    [self addSubview:imageStandLine];
    [imageStandLine autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:3.];
    [imageStandLine autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:3.];
    [imageStandLine autoPinEdge:ALEdgeTrailing toEdge:ALEdgeLeading ofView:imageArrow];
    [imageStandLine autoSetDimension:ALDimensionWidth toSize:1];
    
    // Label
    self.labelTitle = [[UILabel alloc] initForAutoLayout];
    [self.labelTitle setFont:[FontUtils aileronRegularWithSize:14]];
    [self.labelTitle setTextColor:PHR_COLOR_TEXT_GRAY];
    [self addSubview:self.labelTitle];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.labelTitle autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.labelTitle autoPinEdge:ALEdgeTrailing toEdge:ALEdgeLeading ofView:imageStandLine withOffset:2];
    [self.labelTitle autoPinEdge:ALEdgeBottom toEdge:ALEdgeTop ofView:imageUnderline];
    
    // Click
    [self addTarget:self action:@selector(onClicked) forControlEvents:UIControlEventTouchUpInside];
}

- (void)setText:(NSString*)text {
    if (!text && self.arrayChoices) {
        text = self.arrayChoices[0];
    }
    [self.labelTitle setText:text];
}

- (NSString*)getText {
    return self.labelTitle.text;
}

- (void)setClickEnable:(BOOL)enable {
    [self setEnabled:enable];
}

- (void)setArrayChoices:(NSArray *)arrayChoices {
    _arrayChoices = arrayChoices;
    if (arrayChoices && arrayChoices.count > 0) {
        [self setText:arrayChoices[0]];
    }
    else{
        [self setText:@""];
    }
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
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleTextPicker];
    [picker setTitlesForComponenets:[NSArray arrayWithObject:_arrayChoices]];
    [picker setSelectedTitles:@[[self getText]]];
    [picker show];
}

#pragma mark - Action sheet delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectTitles:(NSArray *)titles {
    if (!titles || titles.count <= 0) {
        return;
    }
    if (self.delegate) {
        [self.delegate didSelectItem];
    }
    [self setText:titles[0]];
}









@end
