//
//  PHRLineChartDataSet.m
//  PHR
//
//  Created by BillyMobile on 6/7/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChartUtils.h"

@implementation PHRChartUtils

+ (void)setGradient:(LineChartDataSet*)line isShow:(BOOL)isShow{
    NSArray *gradientColors = @[
                                isShow ? (id)[ChartColorTemplates colorFromString:@"#00FFFFFF"].CGColor : (id)[UIColor clearColor].CGColor,
                                isShow ? (id)[ChartColorTemplates colorFromString:@"#99FFFFFF"].CGColor : (id)[UIColor clearColor].CGColor
                                ];
    CGGradientRef gradient = CGGradientCreateWithColors(nil, (CFArrayRef)gradientColors, nil);
    line.fillAlpha = 1.0f;
    line.fill = [ChartFill fillWithLinearGradient:gradient angle:90.f];
    line.drawFilledEnabled = YES;
    
    CGGradientRelease(gradient);
}

+ (void)setStyleMainLine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor {
    // Set 1 - draw y data 1
    [line setColor:lineChartColor];
    [line setCircleColor:[UIColor clearColor]];
    line.lineWidth = 1.;
    line.circleRadius = .0;
    line.drawCircleHoleEnabled = YES;
    line.circleHoleColor = lineChartColor;
    line.circleHoleRadius = 4.0;
    line.valueFont = [UIFont systemFontOfSize:9.f];
    line.drawValuesEnabled = NO;
    line.drawHorizontalHighlightIndicatorEnabled = NO;
    line.axisDependency = AxisDependencyRight;
    line.drawVerticalHighlightIndicatorEnabled = NO;
}

+ (void)setStyleMainLine:(LineChartDataSet*)line {
    [self setStyleMainLine:line withColor:[UIColor whiteColor]];
}

+ (void)setStyleMainLine:(LineChartDataSet*)line withLineColor:(UIColor*)lineColor{
    [self setStyleMainLine:line withColor:lineColor];
}

+ (void)setStyleSecondLine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor{
    [line setColor:lineChartColor];
    [line setCircleColor:[UIColor clearColor]];
    line.lineWidth = 1.;
    line.circleRadius = .0;
    line.drawCircleHoleEnabled = YES;
    line.circleHoleColor = lineChartColor;
    line.circleHoleRadius = 4.0;
    line.valueFont = [UIFont systemFontOfSize:9.f];
    line.drawValuesEnabled = NO;
    line.drawHorizontalHighlightIndicatorEnabled = NO;
    line.axisDependency = AxisDependencyRight;
    line.drawVerticalHighlightIndicatorEnabled = NO;
}

+ (void)setStyleSecondLine:(LineChartDataSet*)line{
    [self setStyleSecondLine:line withColor:[UIColor cyanColor]];
}

+ (void)setStyleSecondLineCustomColor:(LineChartDataSet*)line color:(UIColor*)color {
    [self setStyleSecondLine:line withColor:color];
}

+ (void)setStyleSecondLineWhiteColor:(LineChartDataSet*)line{
    [self setStyleSecondLine:line withColor:[UIColor whiteColor]];
}

+ (void)setStyleSMALine:(LineChartDataSet*)line withColor:(UIColor *)lineChartColor{
    [line setColor:lineChartColor];
    line.drawCubicEnabled = YES;
    line.cubicIntensity = 0;
    line.drawCirclesEnabled = NO;
    line.lineWidth = 1.5;
    line.circleRadius = 4.0;
    [line setCircleColor:UIColor.whiteColor];
//    line.highlightColor = [UIColor colorWithRed:244/255.f green:117/255.f blue:117/255.f alpha:1.f];
    [line setColor:UIColor.blueColor];
    line.fillColor = UIColor.blueColor;
    line.fillAlpha = 1.f;
    line.drawValuesEnabled = NO;
    line.drawHorizontalHighlightIndicatorEnabled = NO;
    line.axisDependency = AxisDependencyRight;
}

+ (void)setStyleSMALine:(LineChartDataSet*)line{
    [self setStyleSMALine:line withColor:[UIColor redColor]];
}

+ (NSString*)getChartType:(int)screen andIndex:(int)index {
     NSString *healthkitType;
    switch (screen) {
        case StandardHomeTypeBodyMeasurement:{
            if (index == ChartContentTypeHeight) {
                healthkitType = HKQuantityTypeIdentifierHeight;
            } else if (index == ChartContentTypeWeight) {
                healthkitType = HKQuantityTypeIdentifierBodyMass;
            } else if (index == ChartContentTypeBodyFat) {
                healthkitType = HKQuantityTypeIdentifierBodyFatPercentage;
            } else if (index == ChartContentTypeBMI) {
                healthkitType = HKQuantityTypeIdentifierBodyMassIndex;
            }
        }
            break;
        case StandardHomeTypeFood:{
            if (index == ChartFoodTypeCalories) {
                healthkitType = HKQuantityTypeIdentifierDietaryEnergyConsumed;
            } else if (index == ChartFoodTypeCarbohydrates) {
                healthkitType = HKQuantityTypeIdentifierDietaryCarbohydrates;
            } else if (index == ChartFoodTypeTotalFat) {
                healthkitType = HKQuantityTypeIdentifierDietaryFatTotal;
            }
        }
            break;
        case StandardHomeTypeTemprature:{
            if (index == PHRChartTemperature) {
                healthkitType = HKQuantityTypeIdentifierBodyTemperature;
            } else if (index == PHRChartHeartRate) {
                healthkitType = HKQuantityTypeIdentifierHeartRate;
            } else if (index == PHRChartPrespiratory) {
                healthkitType = HKQuantityTypeIdentifierRespiratoryRate;
            } else if (index == PHRChartBloodPressure) {
                healthkitType = HKQuantityTypeIdentifierBloodPressureDiastolic;
            } else if (index == PHRChartBloodPressureHigh) {
                healthkitType = HKQuantityTypeIdentifierBloodPressureSystolic;
            }
        }
            break;
        case StandardHomeTypeFitness:{
            if (index == ChartFitnessTypeSteps) {
                healthkitType = HKQuantityTypeIdentifierStepCount;
            } else if (index == ChartFitnessTypeWalkRun) {
                healthkitType = HKQuantityTypeIdentifierDistanceWalkingRunning;
            }
        }
            break;
        case PHRBabyGroupTypeGrowth:{
            if (index == ChartContentTypeHeight) {
                healthkitType = HKQuantityTypeIdentifierHeight;
            } else if (index == ChartContentTypeWeight) {
                healthkitType = HKQuantityTypeIdentifierBodyMass;
            }
            break;
        }
        case PHRBabyGroupTypeFood: {
            healthkitType = PHR_BABY_FOOD_TYPE;
            break;
        }
        case StandardHomeTypeLifeStyle:{
            healthkitType = HKCategoryTypeIdentifierSleepAnalysis;
             break;
        }
        case PHRBabyGroupTypeMilk:{
            if (index == ChartBabyMilkTypeMother) {
                healthkitType = @"MotherMilk";
            } else if (index == ChartBabyMilkTypeBottle) {
                healthkitType = @"BottleMilk";
            }
            break;
        }
        case PHRBabyGroupTypeDiaper:{
            healthkitType = PHR_BABY_DIAPER_TYPE;
            break;
        }
        default:
            break;
    }
    NSLog(@"type: %@",healthkitType);
    return healthkitType;
}

+ (NSMutableArray*)calculateAverage:(NSMutableArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) duration {
    NSCalendar *calendar = [NSCalendar currentCalendar];
    NSDateComponents *components = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:databaseSample.record_date];

    NSInteger hourOfDatabaseSample = [components hour];
    NSInteger dayOfDatabaseSample = [components day];
    NSInteger monthOfDatabaseSample = [components month];
    NSInteger yearOfDatabaseSample = [components year];
//    NSInteger yearForWeekOfYearDatabaseSample = [components yearForWeekOfYear];
//    NSInteger weekOfYearDatabaseSample = [components weekOfYear];
    int dayBetween = [self daysBetween:databaseSample.record_date and:[NSDate date]];
    for (int i = 0; i < arrayData.count; i++) {
        PHRSample* serverSample = [arrayData objectAtIndex:i];
        NSDateComponents *serverComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:serverSample.record_date];
        if (duration == ButtonTimeIntervalDaily) {

            if (hourOfDatabaseSample == [serverComponent hour] && dayOfDatabaseSample == [serverComponent day]
                 && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = (serverSample.value + databaseSample.value) / (arrayData.count + 1);
                break;
            }
            
            if (i == arrayData.count - 1 && dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            
            if (dayOfDatabaseSample == [serverComponent day] && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = (serverSample.value + databaseSample.value) / (arrayData.count + 1);
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            if (dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = (serverSample.value + databaseSample.value) / (arrayData.count + 1);
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            if (monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = (serverSample.value + databaseSample.value) / (arrayData.count + 1);
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
                break;
            }
        }
    }
    
    if (arrayData.count == 0) {
       
        if (duration == ButtonTimeIntervalDaily) {
             NSDateComponents *currentComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:[NSDate date]];
            if (dayOfDatabaseSample == [currentComponent day]
                && monthOfDatabaseSample == [currentComponent month] && yearOfDatabaseSample == [currentComponent year]) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            if (dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            
            if (dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            
            if (dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
            }
        }
    }
    return arrayData;
}

+ (void)calculateSum:(NSMutableArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) duration {
    NSCalendar *calendar = [NSCalendar currentCalendar];
    NSDateComponents *components = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:databaseSample.record_date];
    NSInteger hourOfDatabaseSample = [components hour];
    NSInteger dayOfDatabaseSample = [components day];
    NSInteger monthOfDatabaseSample = [components month];
    NSInteger yearOfDatabaseSample = [components year];
//    NSInteger yearForWeekOfYearDatabaseSample = [components yearForWeekOfYear];
//    NSInteger weekOfYearDatabaseSample = [components weekOfYear];
    int dayBetween = [self daysBetween:databaseSample.record_date and:[NSDate date]];
    
    for (int i = 0; i < arrayData.count; i++) {
        PHRSample* serverSample = [arrayData objectAtIndex:i];
        NSDateComponents *serverComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:serverSample.record_date];
        
        if (duration == ButtonTimeIntervalDaily) {
            
            if (hourOfDatabaseSample == [serverComponent hour] && dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = serverSample.value + databaseSample.value;
                break;
            }
            
            if (i == arrayData.count - 1 && dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            int dayBetween = [self daysBetween:databaseSample.record_date and:[NSDate date]];
            
            if ( dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = serverSample.value + databaseSample.value;
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            
            if (dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = serverSample.value + databaseSample.value;
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            
            if (monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                serverSample.value = serverSample.value + databaseSample.value;
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
                break;
            }
        }
    }
    if (arrayData.count == 0) {
       
        if (duration == ButtonTimeIntervalDaily) {
            NSDateComponents *currentComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:[NSDate date]];
            if (dayOfDatabaseSample == [currentComponent day]
                && monthOfDatabaseSample == [currentComponent month] && yearOfDatabaseSample == [currentComponent year]) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            if (dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            
            if (dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            
            if (dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
            }
        }
    }
}

+ (NSMutableArray*)calculateMinMax:(NSMutableArray*)arrayData andSample:(PHRSample*)databaseSample duration:(ButtonTimeIntervalClick) duration  {
    NSCalendar *calendar = [NSCalendar currentCalendar];
    NSDateComponents *components = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:databaseSample.record_date];
    
    NSInteger hourOfDatabaseSample = [components hour];
    NSInteger dayOfDatabaseSample = [components day];
    NSInteger monthOfDatabaseSample = [components month];
    NSInteger yearOfDatabaseSample = [components year];
//    NSInteger yearForWeekOfYearDatabaseSample = [components yearForWeekOfYear];
//    NSInteger weekOfYearDatabaseSample = [components weekOfYear];
    int dayBetween = [self daysBetween:databaseSample.record_date and:[NSDate date]];
    
    for (int i = 0; i < arrayData.count; i++) {
        PHRSample* serverSample = [arrayData objectAtIndex:i];
        NSDateComponents *serverComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:serverSample.record_date];
        if (duration == ButtonTimeIntervalDaily) {
            
            if (hourOfDatabaseSample == [serverComponent hour] && dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                if (serverSample.value > databaseSample.value) {
                    serverSample.value = databaseSample.value;
                }
                if (serverSample.value2 < databaseSample.value2) {
                    serverSample.value2 = databaseSample.value2;
                }
                break;
            }
            
            if (i == arrayData.count - 1 && dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            
            if (dayOfDatabaseSample == [serverComponent day] && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                if (serverSample.value > databaseSample.value) {
                    serverSample.value = databaseSample.value;
                }
                if (serverSample.value2 < databaseSample.value2) {
                    serverSample.value2 = databaseSample.value2;
                }
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            
            if (dayOfDatabaseSample == [serverComponent day]
                && monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                if (serverSample.value > databaseSample.value) {
                    serverSample.value = databaseSample.value;
                }
                if (serverSample.value2 < databaseSample.value2) {
                    serverSample.value2 = databaseSample.value2;
                }
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            
            if (monthOfDatabaseSample == [serverComponent month] && yearOfDatabaseSample == [serverComponent year]) {
                if (serverSample.value > databaseSample.value) {
                    serverSample.value = databaseSample.value;
                }
                if (serverSample.value2 < databaseSample.value2) {
                    serverSample.value2 = databaseSample.value2;
                }
                break;
            }
            
            if (i == arrayData.count - 1 && dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
                break;
            }
            
        }
    }
    if (arrayData.count == 0) {
        if (duration == ButtonTimeIntervalDaily) {
            NSDateComponents *currentComponent = [calendar components:(NSCalendarUnitHour | NSCalendarUnitDay | NSCalendarUnitMonth | NSCalendarUnitYear | NSCalendarUnitYearForWeekOfYear | NSCalendarUnitWeekOfYear) fromDate:[NSDate date]];
            if (dayOfDatabaseSample == [currentComponent day]
                && monthOfDatabaseSample == [currentComponent month] && yearOfDatabaseSample == [currentComponent year]) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalWeekly) {
            if (dayBetween >= 0 && dayBetween <= 7) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalMonthly) {
            
            if (dayBetween >= 0 && dayBetween <= 30) {
                [arrayData addObject:databaseSample];
            }
            
        } else if (duration == ButtonTimeIntervalYear) {
            
            if (dayBetween >= 0 && dayBetween <= 365) {
                [arrayData addObject:databaseSample];
            }
        }
    }
    return arrayData;
}

+ (int)daysBetween:(NSDate *)date1 and:(NSDate *)date2 {
    NSUInteger unitFlags = NSCalendarUnitDay;
    NSCalendar *calendar = [[NSCalendar alloc] initWithCalendarIdentifier:NSCalendarIdentifierGregorian];
    NSDateComponents *components = [calendar components:unitFlags fromDate:date1 toDate:date2 options:0];
    return (int)[components day];
}

@end
