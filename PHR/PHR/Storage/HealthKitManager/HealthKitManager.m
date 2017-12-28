//
//  HealthKitManager.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 6/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "HealthKitManager.h"
#import "StorageManager.h"
#import "StorageSetting.h"
#import "PHRSample.h"

@interface HealthKitManager ()

@property (nonatomic, retain) HKHealthStore *healthStore;
@property (nonatomic, strong) NSArray *shareObjectTypes;

@end

@implementation HealthKitManager

+ (HealthKitManager *)sharedManager {
  static dispatch_once_t pred = 0;
  static HealthKitManager *instance = nil;
  dispatch_once(&pred, ^{
    instance = [[HealthKitManager alloc] init];
    instance.healthStore = [[HKHealthStore alloc] init];
  });
  return instance;
}

- (void)startSyncHealthkit {

  StorageSetting *setting = [[StorageManager instance] settingForProfile:PHRAppStatus.masterProfileId];
  __weak __typeof__(self) weakSelf = self;
  if ([PHRAppStatus.is_fist_sync isEqualToString:@"1"]) {
    
    [NSUtils showMessage:kLocalizedString(kAlertStart) withTitle:kLocalizedString(kAlert)];
    
    [self readDataFromHealthKitTypes:self.shareObjectTypes start:(setting && setting.lastDateReadHealthKit ? setting.lastDateReadHealthKit : nil) endDate:nil isReceiveDataFromHealthKit:NO withCompletion:^{
      [weakSelf setUpHealthKitBackgroundDelivery];
    }];
  } else {
    
    if (setting.lastDateReadHealthKit == nil) {
      NSDate *date = [NSDate dateWithTimeInterval:1.0 sinceDate:[NSUtils dateFromString:PHRAppStatus.latest_sync_time withFormat:@"YYYY-MM-dd\'T\'HH:mm:ssZ"]];
      [self readDataFromHealthKitTypes:self.shareObjectTypes start:date endDate:nil isReceiveDataFromHealthKit:NO withCompletion:^{
        [weakSelf setUpHealthKitBackgroundDelivery]; 
      }];
    }else{
      [self readDataFromHealthKitTypes:self.shareObjectTypes start:setting.lastDateReadHealthKit endDate:nil isReceiveDataFromHealthKit:YES withCompletion:^{
        [weakSelf setUpHealthKitBackgroundDelivery];
      }];
    }
  }
}

- (void)requestAuthorization {
  
  if ([HKHealthStore isHealthDataAvailable] == NO) {
    // If our device doesn't support HealthKit -> return.
    return;
  }
  self.shareObjectTypes = [NSArray arrayWithObjects:
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierDistanceWalkingRunning],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierStepCount],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierDietaryCarbohydrates],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierDietaryFatTotal],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierDietaryEnergyConsumed],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierRespiratoryRate],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierHeartRate],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBodyTemperature],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBodyFatPercentage],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBodyMass],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierHeight],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBodyMassIndex],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBloodPressureSystolic],
                           [HKObjectType quantityTypeForIdentifier:HKQuantityTypeIdentifierBloodPressureDiastolic],
                           [HKObjectType categoryTypeForIdentifier:HKCategoryTypeIdentifierSleepAnalysis],
                           nil];
  NSSet *types = [NSSet setWithArray:self.shareObjectTypes];
  [self.healthStore requestAuthorizationToShareTypes:types
                                           readTypes:types completion:^(BOOL success, NSError *error) {
                                             if(success) {
                                               
                                               if (self.onAuthorizedSuccess) {
                                                 self.onAuthorizedSuccess();
                                                 
                                               }
                                             } else {
                                               //
                                             }
                                           }];
}

// ----------------- Read Data ----------------------
#pragma Read Data
- (void)readDataFromHealthKitTypes:(NSArray*)types withCompletion:(void (^)(void))completion {
  StorageSetting *setting = [[StorageManager instance] settingForProfile:PHRAppStatus.masterProfileId];
  
  [self readDataFromHealthKitTypes:types start:setting.lastDateReadHealthKit endDate:nil isReceiveDataFromHealthKit:YES withCompletion:^{
    completion();
  }];
  
}

- (void)readDataFromHealthKitTypes:(NSArray*)types start:(NSDate*)startDate endDate:(NSDate*)endDate isReceiveDataFromHealthKit: (BOOL) isReceiveDataFromHealthKit withCompletion:(void (^)(void))completion {
  
  NSLog(@"typestypestypes %@",types);
  
  if(![HealthKitManager allowRead] || PHRAppDelegate.isReadingHealthKit){
    DLog(@"BLACK BLACK BLACK -> not allow read HK");
    completion();
    return;
  }

  if (!isReceiveDataFromHealthKit) {
    PHRAppDelegate.isReadingHealthKit = YES;
  }
  
  dispatch_group_t serviceGroup = dispatch_group_create();
  for(NSInteger i = 0; i < types.count; i++) {
    HKObjectType *hkObjectType = types[i];
    NSString* type = hkObjectType.identifier;
    DLog(@"readDataFromHealthKit %@",type);
    dispatch_group_enter(serviceGroup);
    if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) { //Only need Diastolic
      dispatch_group_leave(serviceGroup);
    } else {
      [self readFromHealthKitWithType:type startDate:startDate endDate:endDate withCompletion:^(NSArray *results){
        // Save data to storage
        //dispatch_async(dispatch_get_main_queue(), ^(){
        if (results.count > 0){
          [[StorageManager instance] readHealthkitSamples:results type:type isNotifyNeeded: isReceiveDataFromHealthKit withCompletion:^{
            
            dispatch_group_leave(serviceGroup);
          }];
        } else {
          dispatch_group_leave(serviceGroup);
        }
      } error:^(NSError* error){
        DLog(@"readDataFromHealthKit %@", error.description);
        dispatch_group_leave(serviceGroup);
      }];
    }
  }
  dispatch_group_notify(serviceGroup,dispatch_get_main_queue(),^{
    DLog(@"readDataFromHealthKit finished");
    PHRAppDelegate.isReadingHealthKit = NO;
    if (!isReceiveDataFromHealthKit) {
      [NSUtils showMessage:kLocalizedString(kAlertFinish) withTitle:kLocalizedString(kAlert)];
    }
    completion();
    
  });
}

- (void)readFromHealthKitWithType:(NSString*)type startDate:(NSDate*)startDate endDate:(NSDate*)endDate withCompletion:(void (^) (NSArray*))completeBlock error:(void (^) (NSError*))errorBlock {
  
  NSPredicate *predicate = nil;
  NSDate *start = nil;
  if (startDate) {
    start = [startDate dateByAddingTimeInterval:-60];
  }
  if (start || endDate) {
    predicate = [HKQuery predicateForSamplesWithStartDate:start endDate:endDate options:HKQueryOptionStrictStartDate];
  }
  else{
    predicate = [HKQuery predicateForSamplesWithStartDate:start endDate:[NSDate date] options:HKQueryOptionStrictStartDate];
  }
  
  if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
    
    HKCorrelationType *bloodPressureType = [HKObjectType correlationTypeForIdentifier:
                                            HKCorrelationTypeIdentifierBloodPressure];
    
    
    HKCorrelationQuery *query = [[HKCorrelationQuery alloc] initWithType:bloodPressureType predicate:predicate samplePredicates:nil completion:^(HKCorrelationQuery *query, NSArray *results, NSError *error) {
      if(!error && results && completeBlock) {
        completeBlock(results);
      } else {
        if (errorBlock) {
          errorBlock(error);
        }
      }
    }];
    [self.healthStore executeQuery:query];
  } else {
    // Use the sample type for step count
    HKSampleType *sampleType = [type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis] ? [HKSampleType categoryTypeForIdentifier:type] : [HKSampleType quantityTypeForIdentifier:type];
    
    
    // Create a sort descriptor for sorting by start date
    NSSortDescriptor *sortDescriptor = [NSSortDescriptor sortDescriptorWithKey:HKSampleSortIdentifierStartDate ascending:YES];
    
    HKSampleQuery *sampleQuery = [[HKSampleQuery alloc] initWithSampleType:sampleType
                                                                 predicate:predicate
                                                                     limit:HKObjectQueryNoLimit
                                                           sortDescriptors:@[sortDescriptor]
                                                            resultsHandler:^(HKSampleQuery *query, NSArray *results, NSError *error) {
                                                              if(!error && results && completeBlock) {
                                                                completeBlock(results);
                                                              } else {
                                                                if (errorBlock) {
                                                                  errorBlock(error);
                                                                }
                                                              }
                                                            }];
    
    [self.healthStore executeQuery:sampleQuery];
  }
}

- (void)setUpHealthKitBackgroundDelivery {
  
  NSLog(@"%lu",(unsigned long)self.shareObjectTypes.count);
  
  for(NSInteger i = 0; i < self.shareObjectTypes.count; i++) {
    __block HKObjectType *hkObjectType = self.shareObjectTypes[i];
    NSString* type = hkObjectType.identifier;
    DLog(@"readDataFromHealthKit %@",type);
    HKSampleType *sampleType;
    if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) { //Only need Diastolic
      continue;
    } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
      sampleType = [HKObjectType correlationTypeForIdentifier:
                    HKCorrelationTypeIdentifierBloodPressure];
    } else {
      sampleType = [type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis] ? [HKSampleType categoryTypeForIdentifier:type] : [HKSampleType quantityTypeForIdentifier:type];
    }
    HKQuery *query = [[HKObserverQuery alloc] initWithSampleType:sampleType predicate:nil updateHandler:
                      ^void(HKObserverQuery *query, HKObserverQueryCompletionHandler completionHandler, NSError *error) {
                        if (completionHandler) {
                          //Handle query data here
                          
                          [self readDataFromHealthKitTypes:@[hkObjectType] withCompletion:^{
                             completionHandler();
                          }];
                         
                        }
                        
                        
                      }];
    
    [self.healthStore executeQuery:query];
    [self.healthStore enableBackgroundDeliveryForType:hkObjectType frequency:[self frequencyForType:type] withCompletion:^(BOOL success,NSError* error) {
      
      
    }];
    
  }
}

- (HKUpdateFrequency)frequencyForType:(NSString*)type {
  if ([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]){
    return HKUpdateFrequencyHourly;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierStepCount]){
    return HKUpdateFrequencyHourly;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierHeartRate]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMass]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierHeight]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]){
    return HKUpdateFrequencyImmediate;
  }
  else if ([type isEqualToString:HKCorrelationTypeIdentifierBloodPressure]) {
    return HKUpdateFrequencyImmediate;
  }
  return HKUpdateFrequencyImmediate;
}

// ----------------- Write Data ----------------------
#pragma Write Data

- (void)writeDataToHealthKitWithType:(NSDictionary*)data withCompletion:(void (^) (BOOL))completeBlock error:(void (^) (NSError*))errorBlock {
  
  dispatch_group_t serviceGroup = dispatch_group_create();
  for(HKObjectType *hkObjectType in self.shareObjectTypes) {
    NSString* type = hkObjectType.identifier;
    dispatch_group_enter(serviceGroup);
    if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) {
      dispatch_group_leave(serviceGroup);
    } else {
      if([data objectForKey:type]) {
        NSArray *listPHRSamples = [data objectForKey:type];
        NSMutableArray *listHealthKitSamples = [[NSMutableArray alloc] init];
        if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]){
          for (int i = 0; i < listPHRSamples.count; i++) {
            PHRSample *phrSample = [listPHRSamples objectAtIndex:i];
            HKCategorySample *categorySample = [self convertPHRSampleToHKCategory:phrSample];
            [listHealthKitSamples addObject:categorySample];
          }
        } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]){
          for (int i = 0; i < listPHRSamples.count; i++) {
            PHRSample *phrSample = [listPHRSamples objectAtIndex:i];
            HKCorrelation *correlation = [self convertPHRSampleToHKCorrelation:phrSample];
            [listHealthKitSamples addObject:correlation];
          }
        } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureSystolic]) {
          dispatch_group_leave(serviceGroup);
        } else {
          for (int i = 0; i < listPHRSamples.count; i++) {
        //  for (int i = 0; i < 1; i++) {
          //  for (int j = 0 ; j < 300; j++) {
              PHRSample *phrSample = [listPHRSamples objectAtIndex:i];
              HKQuantitySample *quantitySample = [self convertPHRSampleToHKQuantitySample:phrSample];
              [listHealthKitSamples addObject:quantitySample];
            }
        //  }
        }
        
        [self.healthStore saveObjects:listHealthKitSamples withCompletion:^(BOOL success, NSError *error) {
          completeBlock(success);
          dispatch_group_leave(serviceGroup);
        }];
      } else {
        dispatch_group_leave(serviceGroup);
      }
    }
  }
  
  dispatch_group_notify(serviceGroup,dispatch_get_main_queue(),^{
    NSLog(@"finished");
  });
  
}

- (HKQuantitySample*)convertPHRSampleToHKQuantitySample:(PHRSample*)phrSample {
  HKUnit *unit = [PHRSample unitForType:phrSample.type];
  double value;
  if ([phrSample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
    value = phrSample.value / 100;
  } else if ([phrSample.type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]) {
    value = phrSample.value2;
  } else {
    value = phrSample.value;
  }
  
  HKQuantity *quantity = [HKQuantity quantityWithUnit:unit doubleValue:value];
  
  HKQuantityType *type = [HKQuantityType quantityTypeForIdentifier:phrSample.type];
  
  HKQuantitySample *quantitySample = [HKQuantitySample quantitySampleWithType:type quantity:quantity startDate:phrSample.record_date endDate:phrSample.record_date];
  return quantitySample;
}

- (HKCorrelation*)convertPHRSampleToHKCorrelation:(PHRSample*)phrSample {
  HKUnit *bloodPressureUnit = [HKUnit millimeterOfMercuryUnit];
  
  HKQuantity *diastolicQuantity = [HKQuantity quantityWithUnit:bloodPressureUnit doubleValue:phrSample.value];
  HKQuantity *systolicQuantity = [HKQuantity quantityWithUnit:bloodPressureUnit doubleValue:phrSample.value2];
  
  HKQuantityType *DiastolicType = [HKQuantityType quantityTypeForIdentifier:HKQuantityTypeIdentifierBloodPressureDiastolic];
  HKQuantityType *SystolicType = [HKQuantityType quantityTypeForIdentifier:HKQuantityTypeIdentifierBloodPressureSystolic];
  
  HKQuantitySample *diastolicSample = [HKQuantitySample quantitySampleWithType:DiastolicType quantity:diastolicQuantity startDate:phrSample.record_date endDate:phrSample.record_date];
  HKQuantitySample *systolicSample = [HKQuantitySample quantitySampleWithType:SystolicType quantity:systolicQuantity startDate:phrSample.record_date endDate:phrSample.record_date];
  
  
  NSSet *objects=[NSSet setWithObjects:systolicSample,diastolicSample, nil];
  HKCorrelationType *bloodPressureType = [HKObjectType correlationTypeForIdentifier:
                                          HKCorrelationTypeIdentifierBloodPressure];
  HKCorrelation *bloodPressure = [HKCorrelation correlationWithType:bloodPressureType startDate:phrSample.record_date endDate:phrSample.record_date objects:objects];
  
  return bloodPressure;
}

- (HKCategorySample*)convertPHRSampleToHKCategory:(PHRSample*)phrSample {
  HKCategoryType *categoryType = [HKQuantityType categoryTypeForIdentifier:HKCategoryTypeIdentifierSleepAnalysis];
  
  HKCategorySample *categorySample = [HKCategorySample categorySampleWithType:categoryType value:HKCategoryValueSleepAnalysisAsleep startDate:phrSample.record_date endDate:[phrSample endate]];
  
  return categorySample;
}

#pragma mark - SETTING
+ (BOOL)allowRead{
  return [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitRead defaultValue:true];
}

+ (BOOL)allowWrite{
  return [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitWrite defaultValue:true];
}

+ (BOOL)allowSyncOn3G{
  return [NSUtils boolForKey:PHRJNKeyChainAllowSynchronizeHealthKitBy3G defaultValue:false];
}

@end
