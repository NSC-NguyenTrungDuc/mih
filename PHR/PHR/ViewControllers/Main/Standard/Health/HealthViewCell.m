//
//  HealthViewCell.m
//  PHR
//
//  Created by NextopHN on 2/3/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HealthViewCell.h"

static float heatlhFontSize = 11.0;
@implementation HealthViewCell

- (void)awakeFromNib {
    // Initialization code
    [self setupStyleToCell];
    //[self alignCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];
    
    // Configure the view for the selected state
}

- (void)setupStyleToCell {
    [self.labelDate setStyleRegularToLabelWithColor:PHR_COLOR_WHITE andSize:heatlhFontSize];
    
    [self.viewBigBound setBackgroundColor:RGBCOLOR(245.0, 245.0, 245.0)];
    //[self.viewSmallBound setBackgroundColor:[UIColor whiteColor]];
    
    [self setStyleToView:self.viewBigBound];
    //[self setStyleToView:self.viewSmallBound];
    
    //[self.lbDoctor setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:10.0];
    //[self.lbDoctorNote setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:10.0];
    
//    [self.labelTitleWeight setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:11.0];
//    [self.labelTitleHeight setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:11.0];
//    [self.labelHighLowBloodPressure setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:11.0];
//    [self.imageViewWeight setImage:[UIImage imageNamed:@"Icon_Weight"]];
//    [self.imageViewHeight setImage:[UIImage imageNamed:@"Icon_Height"]];
//    [self.imageViewBlood setImage:[UIImage imageNamed:@"Icon_Blood"]];
    
    
    [self.labelValueWeight setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:heatlhFontSize];
    [self.labelValueHeight setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:heatlhFontSize];
    [self.labelValueBloodPressure setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:heatlhFontSize];
    
    //Set Text
    //[self.lbDoctor setText:[NSString stringWithFormat:@"%@:",kLocalizedString(kTitleDoctorNote)]];
    [self.labelTitleWeight setText:kLocalizedString(kPHWeight)];
    [self.labelTitleHeight setText:kLocalizedString(kPHHeight)];
    [self.labelHighLowBloodPressure setText:kLocalizedString(kPHHighLowBlood)];
}

- (void)setStyleToView:(UIView *)objView {
    [objView.layer setBorderWidth:1.0];
    [objView.layer setBorderColor:PHR_COLOR_GRAY.CGColor];
    [objView.layer setCornerRadius:10.0];
    objView.backgroundColor = [UIColor whiteColor];
}

- (void)alignCell {
    CGRect frame1 = self.viewWeight.frame;
    CGRect frame2 = self.viewHeight.frame;
    CGRect frame3 = self.viewBlood.frame;
    CGFloat bigWidth = self.viewBigBound.frame.size.width;
    
    CGRect frameImage1 = self.imageViewWeight.frame;
    CGRect frameImage2 = self.imageViewHeight.frame;
    CGRect frameImage3 = self.imageViewBlood.frame;
    
    CGRect frameLabel1 = self.labelValueWeight.frame;
    CGRect frameLabel2 = self.labelValueHeight.frame;
    CGRect frameLabel3 = self.labelValueBloodPressure.frame;
    
    bigWidth = bigWidth - 10;
    frame1.origin.x = 0.0 * (bigWidth / 3) + 5 ;
    frame1.size.width = bigWidth / 3;
    
    frame2.origin.x = 1.0 * (bigWidth / 3) + 5 ;
    frame2.size.width = bigWidth / 3;
    
    frame3.origin.x = 2.0 * (bigWidth / 3) + 5 ;
    frame3.size.width = bigWidth / 3;
    
    frameImage1.origin.x = frame1.size.width / 2 - frameImage1.size.width / 2;
    frameImage2.origin.x = frame2.size.width / 2 - frameImage2.size.width / 2;
    frameImage3.origin.x = frame3.size.width / 2 - frameImage3.size.width / 2;
    
    frameLabel1.origin.x = frame1.size.width / 2 - frameLabel1.size.width / 2;
    frameLabel2.origin.x = frame2.size.width / 2 - frameLabel2.size.width / 2;
    frameLabel3.origin.x = frame3.size.width / 2 - frameLabel3.size.width / 2;
    
    self.viewWeight.frame = frame1;
    self.viewHeight.frame = frame2;
    self.viewBlood.frame = frame3;
    
    self.imageViewWeight.frame = frameImage1;
    self.imageViewHeight.frame = frameImage2;
    self.imageViewBlood.frame = frameImage3;
    
    self.labelValueWeight.frame = frameLabel1;
    self.labelValueHeight.frame = frameLabel2;
    self.labelValueBloodPressure.frame = frameLabel3;
}
- (void)setDataTotableViewCell:(HealthItem *)standardHealth {
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:standardHealth.dateRecord];
    [self.labelDate setText:[UIUtils formatDateOppositeStyle:dateTime]];
    [self.labelDate setTextColor:[UIColor grayColor]];
    
//    if (![standardHealth.doctorNote isEmpty]) {
//        [self.lbDoctor setText:[NSString stringWithFormat:@"%@:",kLocalizedString(kTitleDoctorNote)]];
//        [self.lbDoctorNote setText:standardHealth.doctorNote];
//    }
//    else {
//        [self.lbDoctor setText:[NSString stringWithFormat:@"%@:",kLocalizedString(kTitleParentNote)]];
//        [self.lbDoctorNote setText:standardHealth.parentNote];
//    }
    
    self.labelValueBloodPressure.numberOfLines = 2;
     
    [self.labelValueHeight setText:[NSString stringWithFormat:@"%@ cm", standardHealth.height]];
    [self.labelValueWeight setText:[NSString stringWithFormat:@"%@ kg", standardHealth.weight]];
    [self.labelValueBloodPressure setText:[NSString stringWithFormat:@"%@/%@\nmmHg", standardHealth.highBloodPress,standardHealth.lowBloodPress]];
}


@end
