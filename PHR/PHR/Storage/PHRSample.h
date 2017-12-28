//
//  PHRSample.h
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>
#import <HealthKit/HealthKit.h>
#import <CoreBluetooth/CoreBluetooth.h>

@interface PHRSample : RLMObject <NSCopying>{
    
}
@property (nonatomic, strong) NSString* profile_id; // master profile id if is healthkit
@property (nonatomic, assign) double value; //data
@property (nonatomic, assign) double value2; // data in case sample has 2 value
@property (nonatomic, assign) double valueMaxHigh; //data
@property (nonatomic, assign) double valueMaxLow;
@property (nonatomic, strong) NSString* type; // type: temperature, step, sleep, ...
@property (nonatomic, strong) NSDate *record_date;// date record
@property (nonatomic, strong) NSString *source_bundle; // source: com.nta.phr, ...
@property (nonatomic, assign) int synced; // Synced to PHR server
@property (nonatomic, assign) int wrote; // Write on Healthkit
@property (nonatomic, strong) NSString *uuid; // id of item when sync from healthkit

- (instancetype)initWithQuantitySample:(HKQuantitySample*)sample profileId:(NSString*)profileId;
- (instancetype)initWithHKCorrelation:(HKCorrelation*)correlation profileId:(NSString*)profileId;
- (instancetype)initWithCategorySample:(HKCategorySample*)sample profileId:(NSString*)profileId;
- (instancetype)initWithCharacteristic:(CBCharacteristic*)sample profileId:(NSString*)profileId;
- (instancetype)initWithCharacteristicBloodPressure:(CBCharacteristic*)sample profileId:(NSString*)profileId;
- (instancetype)initWithBMI_Value:(float)sample profileId:(NSString*)profileId;
-(id) copyWithZone: (NSZone *) zone;
// Convert object/type
- (HKQuantitySample*)quantitySample;
+ (HKUnit*)unitForType:(NSString*)type;
+ (NSString*)serverTypeForType:(NSString*)type;
// Device info
+ (NSString*)bundleAppleHealth;
+ (NSString*)bundleBluetooth;
+ (NSString*)bundle;
+ (NSString*)bundlePHRServer;
+ (NSString*)healthkitTypeFromType:(NSInteger)type fromScreen:(int)screen;
+ (double) getValueForBluetooth:(CBCharacteristic*)sample;
+(float) parseBloodPressureObj:(uint16_t) data;
// Convert data
- (NSDate*)endate;

- (double)hourValue;

@end
