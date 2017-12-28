//
//  PHRChart.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/16/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRChart.h"


@implementation PHRChart {
    float maxLineYAxis;
    float average;
    float meanValue;
    float maxRange;
    float minRange;
    NSString *strAverage;
    NSString *chartUnit;
    NSString *chartTitle;
    UIColor *lineChartColor;
    UIColor *fillBalloonColor;
    int isShowDigits;
    BOOL isShowGradient;
    BOOL isBaby;
    BOOL isDetailChart;// dont show color if chart is detail chart
    NSNumberFormatter *formatter;
}

- (void)doCustomize {
    [self setLeftAxisEnable:NO rightAxisEnable:YES];
    [self setLeftAxisDrawGrid:NO rightAxisDrawGrid:NO];
    [self setRightAxisMin:0 max:100];
    [self setXAxisLineColor:[UIColor whiteColor]];
    [self typeForChartTitleAndUnit];
    [self initFormatter];
    [self setMarker];
}

- (void)initFormatter {
    formatter = [[NSNumberFormatter alloc] init];
    if (isShowDigits == 2) {
        formatter.numberStyle = NSNumberFormatterDecimalStyle;
        formatter.roundingMode = NSNumberFormatterRoundHalfUp;
        formatter.maximumFractionDigits = 2;
        formatter.minimumFractionDigits = 2;
    } else if (isShowDigits == 1){
        formatter.numberStyle = NSNumberFormatterNoStyle;
        formatter.roundingMode = NSNumberFormatterRoundHalfUp;
        formatter.maximumFractionDigits = 1;
        formatter.minimumFractionDigits = 1;
    } else if (isShowDigits == 0){
        formatter.numberStyle = NSNumberFormatterNoStyle;
        formatter.roundingMode = NSNumberFormatterRoundHalfUp;
        formatter.maximumFractionDigits = 0;
        formatter.minimumFractionDigits = 0;
    }
}

- (void)typeForChartTitleAndUnit {
    if ([self.chartType isEqualToString:HKQuantityTypeIdentifierHeight]) {
        chartUnit = kLocalizedString(kUnitCm);
        chartTitle = kLocalizedString(kPHHeight);
        isShowDigits = 1;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
        chartUnit = kLocalizedString(kUnitKg);
        chartTitle = kLocalizedString(kPHWeight);
        isShowDigits = 1;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
        chartUnit = kLocalizedString(kUnitPercent);
        chartTitle = kLocalizedString(kBodyFatPercentage);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
        chartUnit = kLocalizedString(kUnitKgM);
        chartTitle = kLocalizedString(kBMI);
        isShowDigits = 2;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierStepCount]) {
        chartUnit = kLocalizedString(kSteps);
        chartTitle = kLocalizedString(kChartStepCount);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]) {
        chartUnit = kLocalizedString(kUnitKm);
        chartTitle = kLocalizedString(kChartWalkingRunDistance);
        isShowDigits = 2;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]) {
        chartUnit = kLocalizedString(kUnitCal);
        chartTitle = kLocalizedString(kCalories);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]) {
        chartUnit = kLocalizedString(kUnitG);
        chartTitle = kLocalizedString(kCarbohydrate);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]) {
        chartUnit = kLocalizedString(kUnitG);
        chartTitle = kLocalizedString(kTotalFat);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBodyTemperature]) {
        chartUnit = kLocalizedString(kUnitCelsius);
        chartTitle = kLocalizedString(KTemperature);
        isShowDigits = 1;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
        chartUnit = kLocalizedString(kUnitBpm);
        chartTitle = kLocalizedString(KHeartRate);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]) {
        chartUnit = kLocalizedString(kUnitBreathMin);
        chartTitle = kLocalizedString(KPrespiratory);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        chartUnit = kLocalizedString(kUnitMmHG);
        chartTitle = kLocalizedString(KBloodPressure);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]) {
        chartUnit = kLocalizedString(kHour);
        chartTitle = kLocalizedString(kTitleLifeStyle);
        isShowDigits = 2;
    } else if ([self.chartType isEqualToString:@"MotherMilk"]) {
        chartUnit = kLocalizedString(kUnitCal);
        chartTitle = kLocalizedString(kTitleMotherMilk);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:@"BottleMilk"]) {
        chartUnit = kLocalizedString(kUnitCal);
        chartTitle = kLocalizedString(kTitleBottleMilk);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:PHR_BABY_FOOD_TYPE]) {
        chartUnit = kLocalizedString(kUnitCal);
        chartTitle = kLocalizedString(kTitleFood);
        isShowDigits = 0;
    } else if ([self.chartType isEqualToString:PHR_BABY_DIAPER_TYPE]) {
        chartUnit = @"";
        chartTitle = kLocalizedString(kBabyTitleDiaper);
        isShowDigits = 0;
    }
    if (isDetailChart) {
        self.backgroundColor = [UIColor clearColor];
    }
}

- (void)setChartBackgroundColor:(UIColor*)color {
    self.backgroundColor = color;
}

- (void)setLineChartColor:(UIColor*)color andFillBallColor:(UIColor*)fillColor {
    lineChartColor = color;
    fillBalloonColor = fillColor;
}

- (void)setIsShowGradient:(BOOL)isShow andIsDetailChart:(BOOL)isDetail{
    isShowGradient = isShow;
    isDetailChart = isDetail;
    
}

- (void)setIsBabyProfile:(BOOL) isBabyProfile {
    isBaby = isBabyProfile;
}

- (void)setMeanValue:(float) mean {
    meanValue = mean;
}

- (void)setDuration:(int) duration {
    self.chartDuration = duration;
}

- (void)setMarker {
    BalloonMarker *marker = [[BalloonMarker alloc] initWithColor:lineChartColor fillColor:fillBalloonColor font:[UIFont systemFontOfSize:9.0] insets: UIEdgeInsetsMake(2.0, 2.0, 5.0, 2.0)];
    marker.minimumSize = CGSizeMake(25.0, 15.0);
    marker.isShowDigit = isShowDigits;
    self.chartView.marker = marker;
}

- (void)updateChartData {
    [super updateChartData];
    [self processData];
    [self.chartView animateWithXAxisDuration:1.5 easingOption:ChartEasingOptionEaseInOutQuart];
}

- (void)calculateMeanValue {
    meanValue = [NSUtils getStandardValue:isBaby masterDataType:self.chartType];
}

- (void)calculateMinMaxRange {
    if (isBaby) {
        CGPoint minMaxData = [MasterDataManager getMinMaxData:PHRAppStatus.currentBaby.isMen withType:[NSUtils  typeForMasterDataType:self.chartType] age:PHRAppStatus.currentBaby.age];
        maxRange = minMaxData.x;
        minRange = minMaxData.y;
    } else {
        CGPoint minMaxData = [MasterDataManager getMinMaxData:PHRAppStatus.currentStandard.isMen withType:[NSUtils  typeForMasterDataType:self.chartType] age:PHRAppStatus.currentStandard.age];
        maxRange = minMaxData.x;
        minRange = minMaxData.y;
    }
}

- (void)calculateMinMax {
//    [self calculateMeanValue];
//    [self calculateMinMaxRange];
    
    self.minAxisValue = 0;
    self.maxAxisValue = 0;
    average = 0;
    if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]){
        float averageBloodHigh = 0;
        if (self.arrayAllData.count > 0) {
            for (PHRSample *obj in self.arrayAllData){
                double maxValue = MAX(MAX(MAX(obj.value2, obj.value),obj.valueMaxHigh),obj.valueMaxLow);
                if (self.maxAxisValue < maxValue) {
                    self.maxAxisValue = maxValue;
                    maxLineYAxis = self.maxAxisValue;
                }
                
                double minValue = MIN(MIN(MIN(obj.value2, obj.value),obj.valueMaxHigh),obj.valueMaxLow);
                if (self.minAxisValue > minValue) {
                    self.minAxisValue = minValue;
                }
                averageBloodHigh += (obj.value2 + obj.valueMaxHigh) / 2;
                average += (obj.value + obj.valueMaxLow) / 2;
            }
            average /= self.arrayAllData.count;
            averageBloodHigh /= (self.arrayAllData.count);
        }
        strAverage = [NSString stringWithFormat:@"%@ %.0f- %.0f %@",kLocalizedString(kTitleAverage),averageBloodHigh, average,chartUnit ];
    } else if([self.chartType isEqualToString:HKQuantityTypeIdentifierHeartRate] || [self.chartType isEqualToString:PHR_BABY_DIAPER_TYPE]) {
        float averageBloodHigh = 0;
        if (self.arrayAllData.count > 0) {
            for (PHRSample *obj in self.arrayAllData){
                double maxValue = MAX(obj.value2, obj.value);
                if (self.maxAxisValue < maxValue) {
                    self.maxAxisValue = maxValue;
                    maxLineYAxis = self.maxAxisValue;
                }
                
                double minValue = MIN(obj.value2, obj.value);
                if (self.minAxisValue > minValue) {
                    self.minAxisValue = minValue;
                }
                averageBloodHigh += obj.value2;
                average += obj.value;
            }
            average /= self.arrayAllData.count;
            averageBloodHigh /= (self.arrayAllData.count);
        }
        strAverage = [NSString stringWithFormat:@"%@ %.2f- %.2f %@",kLocalizedString(kTitleAverage),averageBloodHigh, average,chartUnit ];
    } else {
        if (self.arrayAllData.count > 0) {
            for (PHRSample *obj in self.arrayAllData){
                double maxValue = MAX(maxRange, obj.value);
                if (self.maxAxisValue < maxValue) {
                    self.maxAxisValue = maxValue;
                    maxLineYAxis= self.maxAxisValue;
                }
                 double minValue = MIN(minRange, obj.value);
                if (self.minAxisValue > minValue) {
                    self.minAxisValue = minValue;
                }
                average += obj.value;
            }
            average /= self.arrayAllData.count;
        }
    }
    
    if(self.maxAxisValue == 0){
        maxLineYAxis = 80;
        self.maxAxisValue = 80;
    }
    self.minAxisValue = self.minAxisValue * 0.75;
    self.maxAxisValue = self.maxAxisValue * 1.25;
}

- (void)processData {
    LineChartDataSet *set1;
    LineChartDataSet *setSMA1 = nil;
    LineChartDataSet *setHighLowBlood = nil;
    LineChartDataSet *setMaxHighBlood = nil;
    LineChartDataSet *setMaxLowBlood = nil;
    NSMutableArray *yVals = [[NSMutableArray alloc] init];
    NSMutableArray *yValsHighLow;
    NSMutableArray *yValsMaxHigh;
    NSMutableArray *yValsMaxLow;
    
    [self calculateMinMax];
    
    if (self.arrayAllData.count > 0) {
        [self setRightAxisMin:self.minAxisValue max:self.maxAxisValue];
        self.rightAxis.drawLabelsEnabled = YES;
//        self.rightAxis.rangeViewMax = maxRange;
//        self.rightAxis.rangeViewMin = minRange;
//        self.rightAxis.rangeViewColor = [UIColor colorWithRed:197.0/255.0 green:223.0/255.0 blue:241.0/255.0 alpha:0.8] ;
    } else {
        [self setRightAxisMin:0 max:100];
        self.rightAxis.drawLabelsEnabled = NO;
    }
    
    if (self.arrayAllData.count > 0) {
        for (PHRSample *sample in self.arrayAllData) {
            NSDate *dateTime = sample.record_date;
            if(dateTime != nil){
                if (self.chartDuration == ButtonTimeIntervalDaily) {
                    [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"HH"]];
                } else if (self.chartDuration == ButtonTimeIntervalWeekly) {
                    if (self.arrayXData.count == 0){
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MMMM dd"]];
                    } else {
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"dd"]];
                    }
                } else if (self.chartDuration == ButtonTimeIntervalMonthly) {
                    if (self.arrayXData.count == 0){
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MMMM dd"]];
                    } else {
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"dd"]];
                    }
                } else {
                    if (self.arrayXData.count == 0){
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"YYYY/MM"]];
                    } else {
                        [self.arrayXData addObject:[UIUtils stringDate:dateTime withFormat:@"MM"]];
                    }
                }
            }
            else{
                [self.arrayXData addObject:@""];
            }
        }
            
        for (int i = 0; i < self.arrayAllData.count ; i++) {
            PHRSample *sample = (PHRSample*) self.arrayAllData[i];
            double value;
            if (isShowDigits) {
                value = roundf(sample.value * 100) / 100.0;
            } else {
                value = (int)round(sample.value);
            }
            ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:value xIndex:i];
            [self.arrayYData addObject:chartData];
        }
    }
    
    [self addLimitLine];
    
    //Draw SMA line
    if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        yValsHighLow = [[NSMutableArray alloc] init];
        yValsMaxHigh = [[NSMutableArray alloc] init];
        yValsMaxLow = [[NSMutableArray alloc] init];
        // Low Blood Pressure
        for (int i = 0; i < self.arrayAllData.count ; i++) {
            PHRSample *obj = (PHRSample*) self.arrayAllData[i];
            ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:obj.value2 xIndex:i];
            [yValsHighLow addObject:chartData];
            
            ChartDataEntry *chartDataMaxHigh = [[ChartDataEntry alloc] initWithValue:obj.valueMaxHigh xIndex:i];
            [yValsMaxHigh addObject:chartDataMaxHigh];
            
            ChartDataEntry *chartDataMaxLow = [[ChartDataEntry alloc] initWithValue:obj.valueMaxLow xIndex:i];
            [yValsMaxLow addObject:chartDataMaxLow];
        }
       
    } else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierHeartRate] || [self.chartType isEqualToString:PHR_BABY_DIAPER_TYPE]) {
        yValsHighLow = [[NSMutableArray alloc] init];
        for (int i = 0; i < self.arrayAllData.count ; i++) {
            PHRSample *obj = (PHRSample*) self.arrayAllData[i];
            ChartDataEntry *chartData = [[ChartDataEntry alloc] initWithValue:obj.value2 xIndex:i];
            [yValsHighLow addObject:chartData];
        }
    } else {
       setSMA1 = [self drawSMA];
    }
    
    set1 = [[LineChartDataSet alloc] initWithYVals:self.arrayYData label:nil];
    [PHRChartUtils setStyleMainLine:set1 withLineColor:lineChartColor];
    [PHRChartUtils setGradient:set1 isShow:isShowGradient];
        
    //Add data set
    [yVals addObject:set1];
    if ([self.chartType isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
        setHighLowBlood = [[LineChartDataSet alloc] initWithYVals:yValsHighLow label:nil];
        [PHRChartUtils setStyleSecondLine:setHighLowBlood];
        [yVals addObject:setHighLowBlood];
        
        setMaxHighBlood = [[LineChartDataSet alloc] initWithYVals:yValsMaxHigh label:nil];
        [PHRChartUtils setStyleSecondLine:setMaxHighBlood];
        [yVals addObject:setMaxHighBlood];
        
        setMaxLowBlood = [[LineChartDataSet alloc] initWithYVals:yValsMaxLow label:nil];
        [PHRChartUtils setStyleMainLine:setMaxLowBlood];
        [yVals addObject:setMaxLowBlood];

    }
     else if ([self.chartType isEqualToString:HKQuantityTypeIdentifierHeartRate] || [self.chartType isEqualToString:PHR_BABY_DIAPER_TYPE]) {
         setHighLowBlood = [[LineChartDataSet alloc] initWithYVals:yValsHighLow label:nil];
         [PHRChartUtils setStyleSecondLineCustomColor:setHighLowBlood color:PHR_COLOR_BABY_DIAPER_MAIN_COLOR];
         [yVals addObject:setHighLowBlood];
    } else {
        [yVals addObject:setSMA1];
    }
    
    LineChartData *data = [[LineChartData alloc] initWithXVals:self.arrayXData dataSets:yVals];
    [self.rightAxis setValueFormatter:formatter];
    self.chartView.data = data;
}

- (void)addNewDataChart:(PHRSample*)sample {
//    LineChartData *data = (LineChartData*)self.chartView.data;
//    if (data != nil){
//        LineChartDataSet *set = (LineChartDataSet*)[data getDataSetByIndex:0];
//        LineChartDataSet *set2= (LineChartDataSet*)[data getDataSetByIndex:1];
//
//        
//        if (set != nil) {
//            NSDate  *dateTime = sample.record_date;
//            if(dateTime != nil) {
//                [data addXValue:[UIUtils stringDate:dateTime withFormat:@"MM/dd"]];
//            }
//            if (!isHighLowBloodStyle){
//                double roundedValue = round(sample.value  * 100) / 100;
//                ChartDataEntry *entry = [[ChartDataEntry alloc] initWithValue:roundedValue xIndex:[set entryCount]];
//                [data addEntry:entry dataSetIndex:0];
//            }else{
//                //double roundedValue = round(sample.value2  * 100) / 100;
//                double roundedValue = round(sample.value2);
//                ChartDataEntry *entry = [[ChartDataEntry alloc] initWithValue:roundedValue xIndex:[set entryCount]];
//                [data addEntry:entry dataSetIndex:0];
//            }
//            
//            if (!isHighLowBloodStyle) {
//                //SMA
//                if (set2 != nil) {
//
//                    if ([set entryCount] >= self.SMA_PERIOD ) {
//                        double smaValue;
//                        for (int i = (int)[set entryCount] - 1; i >= (int)[set entryCount] - self.SMA_PERIOD ;i--){
//                            smaValue += [[set entryForIndex:i] value];
//                        }
//                        smaValue /= self.SMA_PERIOD;
//                        double roundedValue = round(smaValue  * 100) / 100;
//                        NSLog(@"smaValue - %f",roundedValue);
//                        ChartDataEntry *entry = [[ChartDataEntry alloc] initWithValue:roundedValue xIndex:[set entryCount] - 1];
//                        [data addEntry:entry dataSetIndex:1];
//                    }
//                
//                }
//            } else {
//                //Blood pressure
//                if (set2 != nil){
//                    ChartDataEntry *entry = [[ChartDataEntry alloc] initWithValue:sample.value xIndex:[set2 entryCount]];
//                    [data addEntry:entry dataSetIndex:1];
//                }
//            }
//        } else {
//            set = [[LineChartDataSet alloc] initWithYVals:self.arrayYData label:nil];
//            [PHRChartUtils setStyleMainLine:set withLineColor:lineChartColor];
//            [PHRChartUtils setGradient:set isShow:isShowGradient];
//        }
//        [self.rightAxis removeAllLimitLines];
//        [self.arrayAllData addObject:sample];
//        [self calculateMinMax];
//        [self setRightAxisMin:self.minAxisValue max:self.maxAxisValue];
//        [self addLimitLine];
//        
//        [self.chartView notifyDataSetChanged];
//        [self.chartView setVisibleXRangeMaximum:30];
//        
//        if ([data xValCount] > 30){
//            [self.chartView setDragEnabled:YES];
//        } else {
//            [self.chartView setDragEnabled:NO];
//        }
//        [self.chartView moveViewToX:[data xValCount] - 31];
//    }
}

- (void)addLimitLine {

    if(self.arrayAllData.count == 0){
        maxLineYAxis = 80;
    } else {
//        [self drawMeanLine];
    }
    //Middle line
//    [self addLimitLineOnRightAxisWithoutText:(CGFloat)((maxLineYAxis + self.minAxisValue) / 2) lineWidth:self.limitLineWidth lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
    //Add top left line
    [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:chartTitle andFont:[FontUtils aileronRegularWithSize:12.0]];
    //Add top right line
    if (self.showAvarage) {
       
        if (![self.chartType isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic] &&
            ![self.chartType isEqualToString:HKQuantityTypeIdentifierHeartRate]) {
            NSString *valueAverageWithDigit;
            if (isShowDigits == 2) {
                valueAverageWithDigit = [NSString stringWithFormat:@"%0.2f", average];
            } else if (isShowDigits == 1){
                valueAverageWithDigit = [NSString stringWithFormat:@"%0.1f", average];
            } else {
                valueAverageWithDigit = [NSString stringWithFormat:@"%0.0f", average];
            }
            strAverage = [NSString stringWithFormat:@"%@ %@ %@",kLocalizedString(kTitleAverage),valueAverageWithDigit,chartUnit];
        }
        [self addLimitLineOnRightAxis:maxLineYAxis * 1.1f lineWidth:self.limitLineWidth * 2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor] andText:strAverage withFont:[FontUtils aileronRegularWithSize:8.0] andTextDirection:ChartLimitLabelPositionRightTop];
    }
    //
//     [self addLimitLineOnRightAxisWithIcon:maxLineYAxis /2 andText:@"1" lineWidth:2.0 lineColor:[UIColor whiteColor] textColor:[UIColor whiteColor]];
}




- (void)drawMeanLine {
    if (meanValue != MasterDataTypeNone) {
        //Mean Line
        [self addLimitLineOnRightAxis:meanValue lineWidth:1.5f lineColor:[UIColor redColor] textColor:[UIColor whiteColor]];
    }
}

@end
