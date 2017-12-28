//
//  PHRSlider.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/13/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRSlider.h"
#import <PureLayout/PureLayout.h>

@implementation PHRSlider {
    int scrollViewHeight;
    int mainLineHeight;
    int secondLineHeight;
    int lineX;
    int numberOfMainLine;
    int numberOfSecondLine;
    //Label
    int labelValueSliderWidth;
    int labelValueSliderHeight;
    int distanceValue;
    int maxValue;
    NSString* addTypeName;
    NSString* unit;
    int numberOfDigit;
    BOOL isLockFutureDate;
    BOOL isHiddenButtonDateTime;
    BOOL isScrollToPosition;
    float screenWidth;
    float defaultValue;
}

- (void)initialize:(id)delegate andAddTypeName:(NSString*) typeName {
    isScrollToPosition = false;
    isHiddenButtonDateTime = false;
    [self typeForUnitAndName:typeName];
    [self initViewHeaderAndMain];
    [self addSubViewToHeaderView];
    [self addSubViewToMainView];
    [self typeForColor:typeName];
    _delegate = delegate;
   
}

- (void)initViewHeaderAndMain {
    CGFloat heightOfHeader = self.frame.size.height / 3;
    
    self.viewHeader = [[UIView alloc] initWithFrame:CGRectMake(0, 0, [[UIScreen mainScreen] bounds].size.width, heightOfHeader)] ;
    self.viewMain = [[UIView alloc] initWithFrame:CGRectMake(0, heightOfHeader, [[UIScreen mainScreen] bounds].size.width, self.frame.size.height - heightOfHeader)];
    
    [self.viewMain setBackgroundColor:[UIColor whiteColor]];
    [self addSubview:self.viewHeader];
    [self addSubview:self.viewMain];
}

- (void)addSubViewToHeaderView {
    UIFont *font = [FontUtils aileronRegularWithSize:12];
    CGFloat padding = 10.0;
    CGFloat labelAddTypeWidth = self.viewHeader.bounds.size.width / 3;
    CGFloat labelValueWidth = self.viewHeader.bounds.size.width / 3;
    CGFloat buttonWidth = self.viewHeader.bounds.size.width / 3;
    //Add Type Label
    [self.viewHeader addSubview:[self setupLabel:addTypeName andRect:CGRectMake(padding, 0, labelAddTypeWidth, self.viewHeader.bounds.size.height) withFont:font andTextColor:PHR_COLOR_TEXT_BLACK]];
    //Add Label value
    
    self.labelValue = [self setupLabel:[NSString stringWithFormat:@"0 %@",unit] andRect:CGRectMake(padding + labelAddTypeWidth, 0, labelValueWidth, self.viewHeader.bounds.size.height) withFont:[FontUtils aileronRegularWithSize:18] andTextColor:[UIColor blackColor]];
    self.labelValue.textAlignment = NSTextAlignmentCenter;
    [self.viewHeader addSubview:self.labelValue];
    
    if (!isHiddenButtonDateTime) {
        self.buttonDateTime = [self setupDateTimeButton:CGRectMake(self.viewHeader.bounds.size.width - buttonWidth, 0, buttonWidth - 5, self.viewHeader.bounds.size.height) andFont:font];
        self.buttonDateTime.titleLabel.lineBreakMode = NSLineBreakByWordWrapping;
    
        [self updateTime:[NSDate date]];
        [self.viewHeader addSubview:self.buttonDateTime];
    }
}


- (void)addSubViewToMainView {
    [self initSlider];
    [self initMiddleLine];
}

- (void)initMiddleLine {
    self.viewMiddleDashedLine = [[UIView alloc] initWithFrame:CGRectMake([[UIScreen mainScreen] bounds].size.width / 2, 0, 1, self.viewMain.bounds.size.height)];
    [self.viewMiddleDashedLine drawDashedLine:PHR_COLOR_TEXT_ORANGE_BOLD];
    [self.viewMain addSubview:self.viewMiddleDashedLine];
}

- (void)initSlider {
    
    screenWidth = CGRectGetWidth([[UIScreen mainScreen] bounds]);
    
    self.scrollView = [[UIScrollView alloc] initWithFrame:self.viewMain.bounds];
    self.scrollView.delegate = self;
    [self.viewMain addSubview:self.scrollView];
    [self.scrollView autoPinEdgeToSuperviewEdge:ALEdgeTop withInset:0];
    [self.scrollView autoPinEdgeToSuperviewEdge:ALEdgeBottom withInset:0];
    [self.scrollView autoPinEdgeToSuperviewEdge:ALEdgeLeading withInset:0];
    [self.scrollView autoPinEdgeToSuperviewEdge:ALEdgeTrailing withInset:0];
    
    //Draw line in slider
    if (distanceValue != 0){
        numberOfMainLine = maxValue / distanceValue;
    }
    
    numberOfSecondLine = 4;
    lineX = screenWidth / 2;
    scrollViewHeight = self.scrollView.frame.size.height;
    mainLineHeight = scrollViewHeight / 3;
    secondLineHeight = scrollViewHeight / 6;
    labelValueSliderWidth = 100.0;
    labelValueSliderHeight = 30.0;
    
    [self drawSlider];
}


- (void)drawSlider {
    UIFont *font = [FontUtils aileronRegularWithSize:12];
    CGFloat posYMainLine = self.viewMain.bounds.size.height / 5;
    CGFloat posYSecondLine = posYMainLine + secondLineHeight / 2;
    
    for (int i = 0; i < numberOfMainLine; i++) {

        for (int j = 0; j < numberOfSecondLine; j++) {
            if (j == 0) {
                [self addLine:lineX andPosY:posYMainLine andLineHeight:mainLineHeight];
                
                NSString *textLabel = [NSString stringWithFormat:@"%d",(i * distanceValue)];
                CGSize sizeOfText = [textLabel sizeWithAttributes:@{NSFontAttributeName: font}];
                [self.scrollView addSubview:[self setupLabel:textLabel andRect:CGRectMake(lineX - sizeOfText.width / 2, posYMainLine + mainLineHeight, labelValueSliderWidth, labelValueSliderHeight) withFont:font andTextColor:[UIColor orangeColor]]];
                
                lineX += PHR_SLIDE_SPACE_BETWEEN_LINE;
            }

            //Add Second Line
            [self addLine:lineX andPosY:posYSecondLine  andLineHeight:secondLineHeight];

            // Add Last Main line
            if (i == numberOfMainLine - 1 && j == numberOfSecondLine - 1) {
                lineX += PHR_SLIDE_SPACE_BETWEEN_LINE;
                [self addLine:lineX andPosY:posYMainLine andLineHeight:mainLineHeight];
                
                NSString *textLabel = [NSString stringWithFormat:@"%d",((i+1) * distanceValue)];
                 CGSize sizeOfText = [textLabel sizeWithAttributes:@{NSFontAttributeName: font}];
                [self.scrollView addSubview:[self setupLabel:textLabel andRect:CGRectMake(lineX - sizeOfText.width / 2,posYMainLine + mainLineHeight, labelValueSliderWidth, labelValueSliderHeight) withFont:font andTextColor:[UIColor orangeColor]]];
                lineX += screenWidth / 2;
            } else {
                lineX += PHR_SLIDE_SPACE_BETWEEN_LINE;
            }

        }
    }
    [self.scrollView setShowsVerticalScrollIndicator:NO];
    [self.scrollView setShowsHorizontalScrollIndicator:NO];
    self.scrollView.decelerationRate = UIScrollViewDecelerationRateNormal;
    self.scrollView.bounces = NO;
    self.scrollView.contentSize = CGSizeMake(lineX, self.scrollView.bounds.size.height / 2);
}

- (void)addLine:(CGFloat) posX andPosY:(CGFloat) posY andLineHeight:(CGFloat)lineHeight {
    UIView *view = [[UIView alloc] initWithFrame:CGRectMake(posX, posY, PHR_SLIDE_LINE_WIDTH , lineHeight)];
    view.backgroundColor = PHR_COLOR_TEXT_ORANGE_BOLD;
    [self.scrollView addSubview:view];
}

- (UILabel*)setupLabel:(NSString*)text andRect:(CGRect)rect withFont:(UIFont*)font  andTextColor:(UIColor*) color {
    UILabel *label = [[UILabel alloc] initWithFrame:rect];
    label.backgroundColor = [UIColor clearColor];
    label.textAlignment = NSTextAlignmentLeft;
    label.font = font;
    label.textColor = color;
    label.numberOfLines = 0;
    label.text = text;
    return label;
}

- (UIButton*)setupDateTimeButton:(CGRect)rect andFont:(UIFont*)font {
    UIButton *button = [UIButton buttonWithType:UIButtonTypeCustom];
    button.layer.borderWidth = 0 ;
    [button addTarget:self
               action:@selector(onClickButtonDateTime:)
     forControlEvents:UIControlEventTouchUpInside];
    [button setTitle:@"Show View" forState:UIControlStateNormal];
    [button setTitleColor:PHR_COLOR_TEXT_BLACK forState:UIControlStateNormal];
    [button.titleLabel setFont:font];
    button.contentHorizontalAlignment = UIControlContentHorizontalAlignmentRight;
    button.frame = rect;
    return button;
}

- (void)scrollViewDidScroll:(UIScrollView *)scrollView {
    float position;
    if (isScrollToPosition) {
        isScrollToPosition = NO;
        position = defaultValue;
    } else {
        float widthOfBlock = (lineX - screenWidth) / numberOfMainLine;
        position = scrollView.contentOffset.x / widthOfBlock * distanceValue;
    }
    if (numberOfDigit == 2) {
        self.labelValue.text = [NSString stringWithFormat:@"%.2f %@",position,unit];
    } else if (numberOfDigit == 1){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f %@",position,unit];
    } else {
        self.labelValue.text = [NSString stringWithFormat:@"%.0f %@",position,unit];
    }
    if (_delegate) {
        [_delegate scrollViewScroll:self value:position];
    }
}

- (void)updateTime:(NSDate *)date {
    if (!date) {
        return;
    }
    _datetime = date;
   
    NSMutableAttributedString *titleString;
  
    if([NSUtils checkDateIsToday:date]) {
        titleString = [[NSMutableAttributedString alloc] initWithString:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:_datetime]]];
    } else {
        titleString = [[NSMutableAttributedString alloc] initWithString:[self stringDateWithShortFormat]];
    }
    [titleString addAttribute:NSUnderlineStyleAttributeName value:[NSNumber numberWithInteger:(NSUnderlinePatternDot|NSUnderlineStyleSingle)] range:NSMakeRange(0, [titleString length])];

    [self.buttonDateTime setAttributedTitle:titleString forState:UIControlStateNormal];
    if (_delegate) {
        [_delegate dateTimeChanged:date];
    }
}

/*
 Datetime string to show on UI
 */
- (NSString*)stringDateWithShortFormat{
    return [UIUtils stringDate:self.datetime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE];
    
}

- (void)onClickButtonDateTime:(UIButton*)sender {
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
    if (isLockFutureDate) {
        [picker setMaximumDate:date];
    }
    [picker show];
    
    if (_delegate) {
        [_delegate dateTimeChanged:date];
    }
}

- (void)scrollToPosition:(float)value {
    defaultValue = value;
    isScrollToPosition = true;
    float xPos =  value * PHR_SLIDE_SPACE_BETWEEN_LINE / (distanceValue / 5);
    [self.scrollView setContentOffset:CGPointMake(xPos, 0) animated:NO];
    
}

- (void)setDateTimeToLabel:(NSDate*)date {
    _datetime = date;
}

#pragma mark - SheetPicker delegate
- (void)actionSheetPickerView:(IQActionSheetPickerView *)pickerView didSelectDate:(NSDate*)date {
    [self updateTime:date];
    
}

- (void)typeForUnitAndName:(NSString*)type {
    if ([type isEqualToString:HKQuantityTypeIdentifierHeight]) {
        
        addTypeName = kLocalizedString(kHeightUppercase);
        unit = kLocalizedString(kUnitCm);
        numberOfDigit = 1;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
        
        addTypeName = kLocalizedString(kWeightUppercase);
        unit = kLocalizedString(kUnitKg);
        numberOfDigit = 1;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
        
        addTypeName = kLocalizedString(kBodyFatPercentage);
        unit = kLocalizedString(kUnitPercent);
        numberOfDigit = 0;
        maxValue = 100;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
        
        addTypeName = kLocalizedString(kBodyMassIndex);
        unit = kLocalizedString(kUnitKgM);
        numberOfDigit = 2;
        maxValue = 100;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]) {
        
        addTypeName = kLocalizedString(kChartStepCountLowCase);
        unit = kLocalizedString(kSteps);
        numberOfDigit = 0;
        maxValue = 50000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]) {
        
        addTypeName = kLocalizedString(kChartWalkingRunDistanceLowCase);
        unit = kLocalizedString(kUnitKm);
        numberOfDigit = 2;
        maxValue = 100;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]) {
        
        addTypeName = kLocalizedString(kCalories);
        unit = kLocalizedString(kUnitCal);
        numberOfDigit = 0;
        maxValue = 10000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]) {
        
        addTypeName = kLocalizedString(kCarbohydrate);
        unit = kLocalizedString(kUnitG);
        numberOfDigit = 0;
        maxValue = 10000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]) {
        
        addTypeName = kLocalizedString(kTotalFat);
        unit = kLocalizedString(kUnitG);
        numberOfDigit = 0;
        maxValue = 10000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]) {
        
        addTypeName = kLocalizedString(KTemperature);
        unit = kLocalizedString(kUnitCelsius);
        numberOfDigit = 1;
        maxValue = 50;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        
        addTypeName = kLocalizedString(kLowBloodPressure);
        unit = kLocalizedString(kUnitMmHG);
        numberOfDigit = 0;
        maxValue = 200;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) {
        
        addTypeName = kLocalizedString(kHighBloodPressure);
        unit = kLocalizedString(kUnitMmHG);
        numberOfDigit = NO;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
        
        addTypeName = kLocalizedString(KHeartRate);
        unit = kLocalizedString(kUnitBpm);
        numberOfDigit = 0;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]) {
        
        addTypeName = kLocalizedString(KPrespiratory);
        unit = kLocalizedString(kUnitBreathMin);
        numberOfDigit = 0;
        maxValue = 50;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:PHR_BABY_MILK_TYPE]) {
        
        addTypeName = kLocalizedString(kCalories);
        unit = kLocalizedString(kUnitCal);
        numberOfDigit = 0;
        maxValue = 10000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:PHR_BABY_MILK_TIME]) {
        
        addTypeName = kLocalizedString(kTime);
        unit = kLocalizedString(kMinute);
        numberOfDigit = 0;
        maxValue = 100;
        distanceValue = 5;
        isLockFutureDate = true;
        isHiddenButtonDateTime = true;
        
    } else if ([type isEqualToString:PHR_BABY_MILK_VOLUME]) {
        
        addTypeName = kLocalizedString(kVolume);
        unit = @"ml";
        numberOfDigit = 0;
        maxValue = 1000;
        distanceValue = 10;
        isLockFutureDate = true;
        isHiddenButtonDateTime = true;
        
    } else if ([type isEqualToString:PHR_BABY_FOOD_TYPE]) {
        
        addTypeName = kLocalizedString(kCalories);
        unit = kLocalizedString(kUnitCal);
        numberOfDigit = 0;
        maxValue = 10000;
        distanceValue = 100;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:PHR_BABY_HK_QUANTITY_HEIGHT]) {
        
        addTypeName = kLocalizedString(kHeightUppercase);
        unit = kLocalizedString(kUnitCm);
        numberOfDigit = 1;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    } else if ([type isEqualToString:PHR_BABY_HK_QUANTITY_BODY_MASS]) {
        
        addTypeName = kLocalizedString(kWeightUppercase);
        unit = kLocalizedString(kUnitKg);
        numberOfDigit = 1;
        maxValue = 300;
        distanceValue = 5;
        isLockFutureDate = true;
        
    }
}

- (void)typeForColor:(NSString*)type {
    if ([type isEqualToString:HKQuantityTypeIdentifierHeight]) {
        [self.viewHeader setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BODY_MEASUREMENT_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BODY_MEASUREMENT_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FITNESS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FITNESS_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FITNESS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FITNESS_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FOOD_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FOOD_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FOOD_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FOOD_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FOOD_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FOOD_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_VITALS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_VITALS_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_VITALS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_VITALS_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_VITALS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_VITALS_MAIN_COLOR];
        [self.buttonDateTime setHidden:YES];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_VITALS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_VITALS_MAIN_COLOR];
        
    } else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_VITALS_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_VITALS_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_MILK_TYPE]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_FOOD_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_FOOD_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_MILK_TIME]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BABY_MILK_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BABY_MILK_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_MILK_VOLUME]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BABY_MILK_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BABY_MILK_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_FOOD_TYPE]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BABY_FOOD_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BABY_FOOD_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_HK_QUANTITY_HEIGHT]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BABY_GROWTH_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR];
        
    } else if ([type isEqualToString:PHR_BABY_HK_QUANTITY_BODY_MASS]) {
        
        [self.viewHeader setBackgroundColor:PHR_COLOR_BABY_GROWTH_LIGHT_COLOR];
        [self.labelValue setTextColor:PHR_COLOR_BABY_GROWTH_MAIN_COLOR];
        
    }
}

- (void)resetView:(NSString*)typeName {
    for (UIView* view in self.subviews) {
        [view removeFromSuperview ];
    }
    [self typeForUnitAndName:typeName];
    [self initViewHeaderAndMain];
    [self addSubViewToHeaderView];
    [self addSubViewToMainView];
    [self typeForColor:typeName];
}
@end

