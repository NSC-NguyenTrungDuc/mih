//
//  StandardFitnessTableViewCell.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 7/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardDetailTableViewCell.h"

@implementation StandardDetailTableViewCell

- (void)awakeFromNib {
    [super awakeFromNib];
    self.viewValue.layer.cornerRadius = 15;
    [self.labelDateTime setTextColor:PHR_COLOR_TEXT_BLACK];
  
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];


}

- (void) setupUIFitness:(FitnessModel*)model type:(ChartFitnessType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel{
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    if(type == ChartFitnessTypeSteps){
        self.labelValue.text = [NSString stringWithFormat:@"%@",model.step];
        
        NSString *rank = [self calculateRanking:[model.step intValue] mean:masterModel.mean andSd:masterModel.sd];
        [self.labelRanking setText:rank];
    } else if (type == ChartFitnessTypeWalkRun){
//      
//      NSLog(@"%@",model.walkrun);
//      
        self.labelValue.text = [NSString stringWithFormat:@"%.2f",[model.walkrun doubleValue]];
         [self.labelRanking setText:@""];
    }
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
 
}

- (void) setupUIBodyMeasurement:(BodyMeasurementModel*)model type:(BodyMeasurementType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    if(type == BodyMeasurementTypeHeight){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f",[model.height doubleValue]];
        
        NSString *rank = [self calculateRanking:[model.height doubleValue] mean:masterModel.mean andSd:masterModel.sd];
        [self.labelRanking setText:rank];
        
    } else if (type == BodyMeasurementTypeWeight){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f",[model.weight doubleValue]];
        
        NSString *rank = [self calculateRankingForWeight:[model.weight doubleValue] mean:masterModel.mean andSd:masterModel.sd obesity:masterModel.obesity];
        NSLog(@"obesity: %f", masterModel.obesity);
        [self.labelRanking setText:rank];
        
    } else if (type == BodyMeasurementTypeBodyFat){
        self.labelValue.text = [NSString stringWithFormat:@"%.2f",[model.percentFat doubleValue]];
        
        NSString *rank = [self calculateRankingForBodyFat:[model.percentFat doubleValue] highMin:masterModel.highMin normalMin:masterModel.normalMin normalMax:masterModel.normalMax highMax:masterModel.highMax];
        [self.labelRanking setText:rank];
        
    } else if (type == BodyMeasurementTypeBMI){
        self.labelValue.text = [NSString stringWithFormat:@"%.2f",[model.bmi doubleValue]];
        
        NSString *rank = [self calculateRankingForBMI:[model.bmi doubleValue] mean:masterModel.mean andSd:masterModel.sd obesity:masterModel.obesity];
        [self.labelRanking setText:rank];
        
    }
    
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }

}

- (void) setupUIFood:(FoodItem*)model type:(FoodType)type color:(UIColor*)color {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    [self.labelRanking setText:@""];
    if(type == FoodTypeCalories){
        self.labelValue.text = [NSString stringWithFormat:@"%.0f",[model.calories doubleValue]];;
    } else if (type == FoodTypeCarbohydrates){
        self.labelValue.text = [NSString stringWithFormat:@"%.0f",[model.carbohydrates doubleValue]];
    } else if (type == FoodTypeTotalFat){
        self.labelValue.text = [NSString stringWithFormat:@"%.0f",[model.totalFat doubleValue]];
    }
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
}

- (void) setupUIVitals:(TemperaturePhysiologyModel*)model type:(PHRTemperatureChartType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    if(type == PHRChartTemperature){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f",[model.temperature doubleValue]];
        
        NSString *rank = [self calculateRankingForTemperature:[model.temperature doubleValue] mean:masterModel.mean highMin:masterModel.highMin normalMin:masterModel.normalMin normalMax:masterModel.normalMax highMax:masterModel.highMax];
        [self.labelRanking setText:rank];
        
    } else if (type == PHRChartBloodPressure){
        self.labelValue.text = [NSString stringWithFormat:@"%@ - %@",model.highBloodPressure,model.lowBloodPressure];
        
        NSString *rank = [self calculateRankingForBloodPressure:[model.highBloodPressure doubleValue] currentValueLow:[model.lowBloodPressure doubleValue] mean:masterModel.mean sd:masterModel.sd lowMean:masterModel.lowBPMean lowSD:masterModel.lowBPSD];
        [self.labelRanking setText:rank];
        
    } else if (type == PHRChartHeartRate){
        self.labelValue.text = [NSString stringWithFormat:@"%@",model.heartRate];
        
        NSString *rank = [self calculateRanking:[model.heartRate intValue] mean:masterModel.mean andSd:masterModel.sd];
        [self.labelRanking setText:rank];
    } else if (type == PHRChartPrespiratory){
        self.labelValue.text = [NSString stringWithFormat:@"%@",model.respiratory];
        [self.labelRanking setText:@""];
    }
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
}

- (void) setupUIBabyMilk:(BabyMilkModel*)model type:(PHRGroupTypeMilk)type color:(UIColor*)color {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    self.labelValue.text = model.calories;
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.time_drink_milk];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
    if (type == PHRGroupTypeMotherMilk){
         self.labelRanking.text = [NSString stringWithFormat:@"%d %@",[model.breast_time intValue], kLocalizedString(kMinute)];
    }
    else {
         self.labelRanking.text = [NSString stringWithFormat:@"%d %@",[model.bottle_milk_volume intValue], kLocalizedString(kVolume)];
    }
}

- (void) setupUIBabyFood:(ChildrenFoodModel*)model color:(UIColor*)color {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    self.labelValue.text = [NSString stringWithFormat:@"%.0f",[model.kcal doubleValue]];;
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.date];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
    self.labelRanking.text = @"";
}

- (void) setupUIBabyGrowth:(BabyGrowth*)model type:(BabyGrowthType)type color:(UIColor*)color masterModel:(MasterDataModel*)masterModel {
    [self.viewValue setBackgroundColor:color];
    [self.labelRanking setTextColor:PHR_COLOR_GRAY_DARK_TEMPERATURE];
    if(type == BabyGrowthHeight){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f",[model.height doubleValue]];
        
        NSString *rank = [self calculateRanking:[model.height doubleValue] mean:masterModel.mean andSd:masterModel.sd];
        [self.labelRanking setText:rank];
    } else if (type == BabyGrowthWeight){
        self.labelValue.text = [NSString stringWithFormat:@"%.1f",[model.weight doubleValue]];
        
        NSString *rank = [self calculateRanking:[model.weight doubleValue] mean:masterModel.mean andSd:masterModel.sd];
        [self.labelRanking setText:rank];
    }
    NSDate  *dateTime = [UIUtils dateFromServerTimeString:model.dateTime];
    if([NSUtils checkDateIsToday:dateTime]) {
        [self.labelDateTime setText:[NSString stringWithFormat:@"%@ - %@",kLocalizedString(kToday), [UIUtils remiderTimeStringFromDate:dateTime]]];
    } else {
        [self.labelDateTime setText:[UIUtils stringDate:dateTime withFormat:PHR_SERVER_DATE_TIME_FORMAT_FOR_MEDICINE]];
    }
}

- (NSString*)calculateRanking:(float)currentValue mean:(float)mean andSd:(float)sd {
    float normalMin = mean - sd;
    float normalMax = mean + sd;
    if (currentValue >= normalMin && currentValue <= mean) {
        return kLocalizedString(kNormal);
    } else if (currentValue > mean && currentValue <= normalMax) {
        return kLocalizedString(kBest);
    } else if (currentValue < normalMin) {
        return kLocalizedString(kLow);
    } else if (currentValue > normalMax) {
        return kLocalizedString(kHigh);
    }
    return @"";
}

- (NSString*)calculateRankingForBMI:(float)currentValue mean:(float)mean andSd:(float)sd obesity:(float)obesity{
    float normalMin = mean - sd;
    float normalMax = mean + sd;

    if (currentValue >= normalMin && currentValue <= normalMax) {
        return kLocalizedString(kNormal);
    } else if (currentValue < normalMin) {
        return kLocalizedString(kLow);
    } else if (currentValue > normalMax && currentValue <= obesity) {
        return kLocalizedString(kHigh);
    } else if (currentValue > obesity) {
        return kLocalizedString(kObesity);
    }
    return @"";
}

- (NSString*)calculateRankingForWeight:(float)currentValue mean:(float)mean andSd:(float)sd obesity:(float)obesity {
    float normalMin = mean - sd;
    float normalMax = mean + sd;
    
    if (currentValue >= normalMin && currentValue <= mean) {
        return kLocalizedString(kNormal);
    } else if (currentValue > mean && currentValue <= normalMax) {
        return kLocalizedString(kBest);
    }  else if (currentValue < normalMin) {
        return kLocalizedString(kLow);
    } else if (currentValue > normalMax && currentValue <= obesity) {
        return kLocalizedString(kHigh);
    } else if (currentValue > obesity) {
        return kLocalizedString(kObesity);
    }
    return @"";
}

- (NSString*)calculateRankingForBodyFat:(float)currentValue highMin:(float)highMin normalMin:(float)normalMin normalMax:(float)normalMax highMax:(float)highMax{

    if (currentValue >= normalMin && currentValue <= normalMax) {
        return kLocalizedString(kNormal);
    } else if (currentValue >= highMin && currentValue < normalMin) {
        return kLocalizedString(kLow);
    } else if (currentValue > normalMax && currentValue <= highMax) {
        return kLocalizedString(kHigh);
    } else if (currentValue < highMin) {
        return kLocalizedString(kLow);
    } else if (currentValue > highMax) {
        return kLocalizedString(kObesity);
    }
    return @"";
}

- (NSString*)calculateRankingForTemperature:(float)currentValue mean:(float)mean highMin:(float)highMin normalMin:(float)normalMin normalMax:(float)normalMax highMax:(float)highMax{
    
    if (currentValue >= normalMin && currentValue <= mean) {
        return kLocalizedString(kNormal);
    } else if (currentValue > mean && currentValue < normalMax) {
        return kLocalizedString(kBest);
    } else if (currentValue > highMax) {
        return kLocalizedString(kFever);
//    } else if (currentValue > normalMax && currentValue <= highMax) {
//        return kLocalizedString(kFever);
    } else if (currentValue < normalMin) {
        return kLocalizedString(kHypothermia);
    } else if (currentValue > normalMax && currentValue <= highMax) {
        return kLocalizedString(kHyperthermia);
    }
    return @"";
}

- (NSString*)calculateRankingForBloodPressure:(float)currentValueHigh currentValueLow:(float)currentValueLow mean:(float)mean sd:(float)sd lowMean:(float)lowMean lowSD:(float)lowSD {
    float normalLowBPMin = lowMean - lowSD;
    float normalLowBPMax = lowMean + lowSD;
    float normalHighBPMin = mean - sd;
    float normalHighBPMax = mean + sd;
    if ((currentValueLow >= normalLowBPMin && currentValueLow <= normalLowBPMax) && (currentValueHigh >= normalHighBPMin && currentValueHigh <= normalHighBPMax)) {
        return kLocalizedString(kBest);
    } else if ((currentValueHigh >= normalHighBPMin && currentValueHigh <= normalHighBPMax) && currentValueLow < normalLowBPMin) {
        return [NSString stringWithFormat:@"%@ - %@",kLocalizedString(kNormal), kLocalizedString(kLow)];
    } else if ((currentValueHigh >= normalHighBPMin && currentValueHigh <= normalHighBPMax) && currentValueLow > normalLowBPMax) {
        return [NSString stringWithFormat:@"%@ - %@",kLocalizedString(kNormal), kLocalizedString(kHigh)];
    } else if (currentValueHigh < normalHighBPMin && (currentValueLow >= normalLowBPMin && currentValueLow <= normalLowBPMax)) {
        return [NSString stringWithFormat:@"%@ - %@",kLocalizedString(kLow), kLocalizedString(kNormal)];
    } else if (currentValueLow < normalLowBPMin && currentValueHigh < normalHighBPMin) {
        return kLocalizedString(kHypotension);
    } else if (currentValueHigh < normalHighBPMin && currentValueLow > normalLowBPMax) {
        return kLocalizedString(kHypertensive);
    } else if (currentValueHigh > normalHighBPMax && (currentValueLow >= normalLowBPMin && currentValueLow <= normalLowBPMax)) {
        return [NSString stringWithFormat:@"%@ - %@",kLocalizedString(kHigh), kLocalizedString(kNormal)];
    } else if (currentValueHigh > normalHighBPMax && currentValueLow < normalLowBPMin) {
        return kLocalizedString(kHypertensive);
    } else if (currentValueHigh > normalHighBPMax && currentValueLow > normalLowBPMax) {
        return kLocalizedString(kHypotension);
    }
    return @"";
}
@end
