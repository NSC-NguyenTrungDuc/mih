//
//  PHRSample.m
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PHRSample.h"
#import "StorageManager.h"
#import "BluetoothManager.h"

@implementation PHRSample {
    
}

- (instancetype)init{
    if (self = [super init]) {
        _synced = 0;
        _wrote = 0;
    }
    return self;
}

- (instancetype)initWithQuantitySample:(HKQuantitySample*)sample profileId:(NSString*)profileId{
    if (self = [self init]) {
        self.profile_id = profileId;
        self.type = sample.quantityType.identifier;
        if ([sample.quantityType.identifier isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
            self.value = [sample.quantity doubleValueForUnit:[PHRSample unitForType:self.type]] * 100;
        } else {
            self.value = [sample.quantity doubleValueForUnit:[PHRSample unitForType:self.type]];
        }
        self.record_date = [UIUtils convertDateUTCDate:sample.startDate withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.source_bundle = sample.source.bundleIdentifier;
        self.uuid = sample.UUID.UUIDString;
        self.wrote = 1;
    }
    return self;
}

- (instancetype)initWithHKCorrelation:(HKCorrelation*)correlation profileId:(NSString*)profileId {
    if (self = [self init]) {
        self.profile_id = profileId;
        NSSet *objects = correlation.objects;
        NSArray *samples = [objects allObjects];
        HKQuantitySample *sampleDiastolic = [samples objectAtIndex:0];
        HKQuantitySample *sampleSystolic = [samples objectAtIndex:1];
        self.type = HKQuantityTypeIdentifierBloodPressureDiastolic;
        HKUnit *unit = [PHRSample unitForType:self.type];
        if ([sampleDiastolic.quantityType.identifier isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
            self.value2 = [sampleSystolic.quantity doubleValueForUnit:unit];
            self.value = [sampleDiastolic.quantity doubleValueForUnit:unit];
            self.valueMaxHigh = self.value2;
            self.valueMaxLow = self.value;
        } else {
            self.value = [sampleSystolic.quantity doubleValueForUnit:unit];
            self.value2 = [sampleDiastolic.quantity doubleValueForUnit:unit];
            self.valueMaxHigh = self.value2;
            self.valueMaxLow = self.value;
        }
        self.record_date =  [UIUtils convertDateUTCDate:correlation.startDate withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.source_bundle = correlation.source.bundleIdentifier;
        self.uuid = correlation.UUID.UUIDString;
        self.wrote = 1;
    }
    return self;
}

- (instancetype)initWithCategorySample:(HKCategorySample*)sample profileId:(NSString*)profileId{
    if (self = [self init]) {
        self.profile_id = profileId;
        self.type = sample.categoryType.identifier;
        self.record_date = [UIUtils convertDateUTCDate:sample.startDate withFormat:PHR_SERVER_DATE_TIME_FORMAT];
        self.value2 = [sample.endDate timeIntervalSinceDate:sample.startDate];
        self.value = self.value2 / 3600;
        self.source_bundle = sample.source.bundleIdentifier;
        self.uuid = sample.UUID.UUIDString;
        self.wrote = 1;
    }
    return self;
}

- (instancetype)initWithCharacteristic:(CBCharacteristic*)sample profileId:(NSString*)profileId{
    if (self = [self init]) {
        self.profile_id = profileId; // master profile id == account id
        self.type = [PHRSample typeForUUID:sample.UUID];
        self.value = [PHRSample getValueForBluetooth:sample];
        self.record_date = [NSDate date];
        self.source_bundle = [PHRSample bundleBluetooth];
    }
    return self;
}

- (instancetype)initWithCharacteristicBloodPressure:(CBCharacteristic*)sample profileId:(NSString*)profileId{
    if (self = [self init]) {
        self.profile_id = profileId; // master profile id == account id
        self.type = [PHRSample typeForUUID:sample.UUID];
        
        NSUInteger len = [sample.value length];
        Byte *byteData = (Byte*)malloc(len);
        memcpy(byteData, [sample.value bytes], len);
        
        uint16_t systolic = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(1, 2)] bytes];
        uint16_t diastolic = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(3, 2)] bytes];
        
        DLog(@"systolic - diastolic:%f - %f",[PHRSample parseBloodPressureObj:systolic],[PHRSample parseBloodPressureObj:diastolic]);
        
        self.value = [PHRSample parseBloodPressureObj:diastolic];
        self.value2 = [PHRSample parseBloodPressureObj:systolic];
        self.valueMaxLow = self.value;
        self.valueMaxHigh = self.value2;
        
        self.record_date = [NSDate date];
        self.source_bundle = [PHRSample bundleBluetooth];
    }
    return self;
}

- (instancetype)initWithBMI_Value:(float)sample profileId:(NSString*)profileId{
    if (self = [self init]) {
        self.profile_id = profileId; // master profile id == account id
        self.type = HKQuantityTypeIdentifierBodyMassIndex;
        
        self.value = (double)sample;
        
        self.record_date = [NSDate date];
        self.source_bundle = [PHRSample bundleBluetooth];
    }
    return self;
}



- (HKQuantitySample*)quantitySample{
    return [HKQuantitySample quantitySampleWithType:[HKQuantityType quantityTypeForIdentifier:self.type] quantity:[HKQuantity quantityWithUnit:[PHRSample unitForType:self.type] doubleValue:self.value] startDate:self.record_date endDate:self.record_date];
}

+ (HKUnit*)unitForType:(NSString*)type{
    if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]){
        return [HKUnit meterUnitWithMetricPrefix:HKMetricPrefixKilo];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]){
        return [HKUnit countUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]){
        return [HKUnit gramUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]){
        return [HKUnit gramUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]){
        return [HKUnit kilocalorieUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]){
        return [HKUnit millimeterOfMercuryUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]){
        return [HKUnit millimeterOfMercuryUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]){
        return [[HKUnit countUnit] unitDividedByUnit:[HKUnit minuteUnit]];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]){
        return [[HKUnit countUnit] unitDividedByUnit:[HKUnit minuteUnit]];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]){
        return [HKUnit degreeCelsiusUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]){
        return [HKUnit countUnit];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]){
        return [HKUnit gramUnitWithMetricPrefix:HKMetricPrefixKilo];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierHeight]){
        return [HKUnit meterUnitWithMetricPrefix:HKMetricPrefixCenti];
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]){
        return [HKUnit countUnit];
    }
    else if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]){
        return [HKUnit minuteUnit];
    } else if ([type isEqualToString:HKCorrelationTypeIdentifierBloodPressure]) {
         return [HKUnit millimeterOfMercuryUnit];
    }
    return nil;
}

+ (NSString*)serverTypeForType:(NSString*)type{
    int value = 0;
    if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]){
        value = PHRFitnessAddTypeWalkingRunDistance;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]){
        value = PHRFitnessAddTypeStepCount;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]){
        value = ChartFoodTypeCarbohydrates;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]){
        value = ChartFoodTypeTotalFat;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]){
        value = ChartFoodTypeCalories;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]){
        value = PHRChartBloodPressure;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]){
        value = PHRChartBloodPressure;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]){
        value = PHRChartPrespiratory;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]){
        value = PHRChartHeartRate;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]){
        value = PHRChartTemperature;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]){
        value = 3;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]){
        value = 1;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierHeight]){
        value = 0;
    }
    else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]){
        value = 2;
    }
//    else if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]){
//        return value = ;
//    }
    return [NSString stringWithFormat: @"0%d", (int)value + 1];
}

+ (NSString*)healthkitTypeFromType:(NSInteger)type fromScreen:(int)screen {
    NSString *healthkitType;
    switch (screen) {
        case StandardHomeTypeBodyMeasurement:{
                if (type == ChartContentTypeHeight) {
                    healthkitType = HKQuantityTypeIdentifierHeight;
                } else if (type == ChartContentTypeWeight) {
                    healthkitType = HKQuantityTypeIdentifierBodyMass;
                } else if (type == ChartContentTypeBodyFat) {
                    healthkitType = HKQuantityTypeIdentifierBodyFatPercentage;
                } else if (type == ChartContentTypeBMI) {
                    healthkitType = HKQuantityTypeIdentifierBodyMassIndex;
                }
        }
            break;
        case StandardHomeTypeFood:{
                if (type == ChartFoodTypeCalories) {
                    healthkitType = HKQuantityTypeIdentifierDietaryEnergyConsumed;
                } else if (type == ChartFoodTypeCarbohydrates) {
                    healthkitType = HKQuantityTypeIdentifierDietaryCarbohydrates;
                } else if (type == ChartFoodTypeTotalFat) {
                    healthkitType = HKQuantityTypeIdentifierDietaryFatTotal;
                }
        }
            break;
        case StandardHomeTypeTemprature:{
                if (type == PHRChartTemperature) {
                    healthkitType = HKQuantityTypeIdentifierBodyTemperature;
                } else if (type == PHRChartHeartRate) {
                    healthkitType = HKQuantityTypeIdentifierHeartRate;
                } else if (type == PHRChartPrespiratory) {
                    healthkitType = HKQuantityTypeIdentifierRespiratoryRate;
                } else if (type == PHRChartBloodPressure) {
                    healthkitType = HKQuantityTypeIdentifierBloodPressureDiastolic;
                }
        }
            break;
        case StandardHomeTypeFitness:{
                if (type == ChartFitnessTypeSteps) {
                    healthkitType = HKQuantityTypeIdentifierStepCount;
                } else if (type == ChartFitnessTypeWalkRun) {
                    healthkitType = HKQuantityTypeIdentifierDistanceWalkingRunning;
                }
        }
            break;
        case PHRBabyGroupTypeGrowth:{
                if (type == ChartContentTypeHeight) {
                    healthkitType = HKQuantityTypeIdentifierHeight;
                } else if (type == ChartContentTypeWeight) {
                    healthkitType = HKQuantityTypeIdentifierBodyMass;
                }
        }
            break;
        case StandardHomeTypeLifeStyle:{
            healthkitType = HKCategoryTypeIdentifierSleepAnalysis;
        }
            break;
        default:
            break;
    }
    return healthkitType;
}

#pragma mark - device info
+ (NSString*)bundleAppleHealth{
    return @"com.apple.health";
}

+ (NSString*)bundleBluetooth{
    return [NSString stringWithFormat:@"%@.bluetooth", [[NSBundle mainBundle] bundleIdentifier]];
}

+ (NSString*)bundle{
    return [[NSBundle mainBundle] bundleIdentifier];
}

+ (NSString*)bundlePHRServer{
    return [NSString stringWithFormat:@"%@.server", [[NSBundle mainBundle] bundleIdentifier]];
}

+ (NSString*)typeForUUID:(CBUUID *) uuid{
    if([uuid isEqual:[CBUUID UUIDWithString:BLECharacteristic_HEART_RATE]]){
        return HKQuantityTypeIdentifierHeartRate;
        
    }else if([uuid isEqual:[CBUUID UUIDWithString:BLECharacteristic_BLOOD_PRESSURE]]){
        return HKQuantityTypeIdentifierBloodPressureDiastolic;
        
    }else if([uuid isEqual:[CBUUID UUIDWithString:BLECharacteristic_BODY_TEMPERATUTE]]){
        return HKQuantityTypeIdentifierBodyTemperature;
        
    }else if([uuid isEqual:[CBUUID UUIDWithString:BLECharacteristic_Weight_Scale]]){
         return HKQuantityTypeIdentifierBodyMass;
        
    }else if([uuid isEqual:[CBUUID UUIDWithString:BLECharacteristic_Body_Composition]]){
        return HKQuantityTypeIdentifierBodyFatPercentage;
    }
    return nil;
}

+ (double) getValueForBluetooth:(CBCharacteristic*)sample{
    // process data
    
    if([[sample.UUID UUIDString] isEqualToString:BLECharacteristic_HEART_RATE]){
        const uint8_t *reportData = [sample.value bytes];
        if(reportData!=nil){
            uint16_t bpm = 0;
            
            if ((reportData[0] & 0x01) == 0){
                /* uint8 bpm */
                bpm = reportData[1];
            }
            else{
                /* uint16 bpm */
                bpm = CFSwapInt16LittleToHost(*(uint16_t *)(&reportData[1]));
            }
            return bpm;
            DLog(@"Data: %hu",bpm);
        }else{
            return 0.0f;
        }

    }else if([[sample.UUID UUIDString] isEqualToString:BLECharacteristic_BODY_TEMPERATUTE]){
        NSUInteger len = [sample.value length];
        Byte *byteData = (Byte*)malloc(len);
        memcpy(byteData, [sample.value bytes], len);
        
        uint8_t temperatureUnit = *(uint8_t*)[[sample.value subdataWithRange:NSMakeRange(0, 1)] bytes];
        DLog(@"Temperature unit:%hhu",temperatureUnit);
        uint16_t temperature = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(1, 2)] bytes];
     
        DLog(@"temperature:%hu",temperature);
        if(temperatureUnit == 6){
            return (float)temperature/10;
        }else if(temperatureUnit == 7){
            return (float)((temperature/10) - 32)/(1.8);
        }
        
    }else if([[sample.UUID UUIDString] isEqualToString:BLECharacteristic_Body_Composition]){
        NSUInteger len = [sample.value length];
        Byte *byteData = (Byte*)malloc(len);
        memcpy(byteData, [sample.value bytes], len);
        
        uint16_t body_fat_percen = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(1, 2)] bytes];
        return body_fat_percen;
        
    }else if([[sample.UUID UUIDString] isEqualToString:BLECharacteristic_Weight_Scale]){
        
        NSUInteger len = [sample.value length];
        Byte *byteData = (Byte*)malloc(len);
        memcpy(byteData, [sample.value bytes], len);
    
        
        uint16_t weight = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(1, 2)] bytes];
//        uint16_t bmi = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(4, 2)] bytes];
//        uint16_t height = *(uint16_t*)[[sample.value subdataWithRange:NSMakeRange(6, 2)] bytes];
        
        //DLog(@"BMI :%hu and height :%hu",bmi,height);
        return weight*0.005;
        
    }else{
        return 0;
    }
    
    return 0.0;
}

+(float) parseBloodPressureObj:(uint16_t) data{
    
    float MAX1 = 61440; // 2^15 + 2^14 + 2^13 + 2^12
    float MAX2 = 57344;
    
    DLog(@"DataData:%hu",data);
    
    if(data < MAX2){
        return data;
    }
    else if(MAX2 < data && data < MAX1){
        return (data - MAX2)/100;
    }else{
        return (data - MAX1)/10;
    }
    
}

- (NSDate*)endate{
    return [self.record_date dateByAddingTimeInterval:self.value];
}

- (double)hourValue{
    if ([self.type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]) {
        return self.value/3600.0;
    }
    return self.value;
}

-(id) copyWithZone: (NSZone *) zone
{
    PHRSample *copy = [[PHRSample allocWithZone: zone] init];
    
    [copy setProfile_id: self.profile_id];
    [copy setValue: self.value];
    [copy setValue2: self.value2];
    
    [copy setType: self.type];
    [copy setRecord_date: self.record_date];
    [copy setSource_bundle: self.source_bundle];
    [copy setSynced: self.synced];
    [copy setWrote: self.wrote];
    [copy setUuid: self.uuid];
    
    return copy;
}

@end
