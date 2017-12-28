//
//  DateTimeView.m
//  PHR
//
//  Created by SonNV1368 on 10/7/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "PHRDateTimeView.h"
#import "IQActionSheetPickerView.h"
#import <PureLayout/PureLayout.h>

@interface PHRDateTimeView () <IQActionSheetPickerViewDelegate>{
    
}
@property (nonatomic, strong) UIButton *buttonOver;
@property (nonatomic, strong) UILabel *labelDateTime;
@property (nonatomic, strong) UIImageView *imageEditable;

@end

@implementation PHRDateTimeView {
    
}


- (id)initWithCoder:(NSCoder *)aDecoder {
    if (self = [super initWithCoder:aDecoder]) {
        [self createContentControl];
    }
    return self;
}

- (instancetype)initWithFrame:(CGRect)frame {
    if (self = [super initWithFrame:frame]) {
        [self createContentControl];
    }
    return self;
}

- (void)setTitleContent:(NSString *)titleContent {
    _titleContent = titleContent;
    self.labelTitleContent.text = _titleContent;
}

- (void)createContentControl {
    // Underline
    UIImageView *imageUnderline = [[UIImageView alloc] initForAutoLayout];
    [imageUnderline setBackgroundColor:[UIColor lightGrayColor]];
    [imageUnderline setAlpha:0.15];
    [self addSubview:imageUnderline];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [imageUnderline autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    [imageUnderline autoSetDimension:ALDimensionHeight toSize:1];
    
    // Title
    _labelTitleContent = [[UILabel alloc] initForAutoLayout];
    _labelTitleContent.text = kLocalizedString(kDATETIME);
    [_labelTitleContent setFont:[FontUtils aileronRegularWithSize:10]];
    [_labelTitleContent setTextColor:PHR_COLOR_GRAY];
    [self addSubview:_labelTitleContent];
    [_labelTitleContent autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [_labelTitleContent autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:3];
    [_labelTitleContent autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [_labelTitleContent autoSetDimension:ALDimensionHeight toSize:12];
    
    // Button select
    self.buttonOver = [[UIButton alloc] initForAutoLayout];
    [self.buttonOver setBackgroundColor:[UIColor clearColor]];
    [self.buttonOver addTarget:self action:@selector(changeDateTime:) forControlEvents:(UIControlEventTouchUpInside)];
    [self addSubview:self.buttonOver];
    [self.buttonOver autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.buttonOver autoPinEdgeToSuperviewEdge:ALEdgeTrailing];
    [self.buttonOver autoPinEdge:ALEdgeTop toEdge:ALEdgeBottom ofView:_labelTitleContent];
    [self.buttonOver autoPinEdge:ALEdgeBottom toEdge:ALEdgeTop ofView:imageUnderline];
    
    
    // Label date
    self.labelDateTime = [[UILabel alloc] initForAutoLayout];
    [self.labelDateTime setFont:[FontUtils aileronRegularWithSize:14]];
    [self.labelDateTime setTextColor:PHR_COLOR_DATE_TIME];
    [self.labelDateTime setText:[self stringDateWithShortFormat:NO]];
    [self.buttonOver addSubview:self.labelDateTime];
    [self.labelDateTime autoPinEdgeToSuperviewEdge:ALEdgeLeading];
    [self.labelDateTime autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [self.labelDateTime autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    
    // Edit icon
    self.imageEditable = [[UIImageView alloc] initForAutoLayout];
    self.imageEditable.image = [UIImage imageNamed:@"Icon_Edited"];
    [self.imageEditable setContentMode:UIViewContentModeCenter];
    [self.buttonOver addSubview:self.imageEditable];
    [self.imageEditable autoPinEdgeToSuperviewEdge:ALEdgeTop];
    [self.imageEditable autoPinEdgeToSuperviewEdge:ALEdgeBottom];
    [self.imageEditable autoPinEdge:ALEdgeLeading toEdge:ALEdgeTrailing ofView:self.labelDateTime];
    [self.imageEditable autoSetDimension:ALDimensionWidth toSize:15];
    
    // Set default date time
    [self updateTime:[NSDate date]];
    
}


// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
//- (void)drawRect:(CGRect)rect {
//    // Drawing code
//}

- (void)setClickEnable:(BOOL)enable {
    [self.buttonOver setEnabled:enable];
    [self.imageEditable setHidden:!enable];
}

- (void)updateTime:(NSDate *)date{
    [self updateTime:date shortFormat:NO];
}

- (void)updateTime:(NSDate *)date shortFormat:(BOOL)shortFormat{
    _datetime = date;
    [self.labelDateTime setText:[self stringDateWithShortFormat:shortFormat]];
}

- (void)updateTimeFromString:(NSString*)strTime {
  [self.labelDateTime setText:strTime];
}

/*
 Datetime string to show on UI
 */
- (NSString*)stringDateWithShortFormat:(BOOL)shortFormat{
    if(!shortFormat){
        return [UIUtils stringDate:self.datetime withFormat:@"hh:mm a yyyy/MM/dd"];
    }else{
        return [UIUtils stringDate:self.datetime withFormat:@"yyyy/MM/dd"];
    }
    
}


/*
 Datetime string as param included in api request
 */
- (NSString*)stringDateParam {
    return [UIUtils stringUTCDate:self.datetime withFormat:PHR_SERVER_DATE_TIME_FORMAT]; // // Server format: yyyy-MM-dd'T'HH:mm:ss'Z'
}

- (void) changeDateTime:(UIButton*)sender {
    // Close keyboard before open date picker
    if ([self superview]) {
        [[self superview] endEditing:YES];
    }
    
    // Date picker
    IQActionSheetPickerView *picker = [[IQActionSheetPickerView alloc] initWithTitle:nil delegate:self];
    NSDate *date = [NSDate date];
    
    [picker setTag:1];
    [picker setActionSheetPickerStyle:IQActionSheetPickerStyleDateTimePicker];
    [picker setDate:self.datetime];
    [picker setMaximumDate:date];
    [picker show];
    
    // callback
    if (self.actionOpenDatePicker) {
        self.actionOpenDatePicker();
    }
}

#pragma mark - SheetPicker delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date {
    [self updateTime:date];
    if (self.actionSelectDate) {
        self.actionSelectDate();
    }
}


@end
