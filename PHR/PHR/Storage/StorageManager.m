//
//  StorageManager.m
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StorageManager.h"
#import "PHRSample.h"
#import "StorageSetting.h"
#import "HealthKitManager.h"

@interface StorageManager() {
}
@property (nonatomic, strong) NSMutableArray *transactionBuffer;
@property (nonatomic, strong) NSMutableArray *samplesBuffer;

@end

@implementation StorageManager {
    long maxIdHk;
    long maxIdBluetooth;
    // timer
    NSTimer *timerSyncServer;
    NSTimer *timerSaveSample;
}

- (instancetype)init{
    if (self = [super init]) {
        _samplesBuffer = [[NSMutableArray alloc] init];
        _transactionBuffer = [[NSMutableArray alloc] init];
    }
    return self;
}

+ (StorageManager*)instance{
    static StorageManager *instance = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        instance = [[StorageManager alloc] init];
    });
    return instance;
}

+ (RLMRealm*)realm{
    NSString *documentsDirectory = NSSearchPathForDirectoriesInDomains(NSDocumentDirectory, NSUserDomainMask, YES)[0];
    NSString *customRealmPath = [documentsDirectory stringByAppendingPathComponent:@"PHRStorage.realm"];
  //  DLog(@"Realm PHRStorage path = %@", customRealmPath);
    return [RLMRealm realmWithURL:[NSURL fileURLWithPath:customRealmPath]];
}

#pragma mark - Sync
- (void)startSyncBluetoothAndPHRData{
    // Create timer to save PHRSample (from bluetooth, PHR) - 30s
    [self saveSamplesBuffer];
    timerSaveSample = [NSTimer scheduledTimerWithTimeInterval:INTERVAL_TIME_SAVED_BLUETOOTH target:self selector:@selector(saveSamplesBuffer) userInfo:nil repeats:YES];
}

- (void)stopSyncBluetoothAndPHRData{
    if (timerSaveSample) {
        [timerSaveSample invalidate];
    }
}

- (void)startSyncDataToServer{
    // Write healthkit data ----> HEALTHKIT
    [self writeHealthKit];
    
    // Create timer to send data to server ---> SERVER
    StorageSetting *setting1 = [PHRAppStatus checkCurrentStandardActive] ? [[StorageManager instance] settingForProfile:PHRAppStatus.currentStandard.profileId] : nil;
    StorageSetting *setting2 = [PHRAppStatus checkCurrentBabyActive] ? [[StorageManager instance] settingForProfile:PHRAppStatus.currentBaby.profileId] : nil;
    NSDate *lastSync = nil;
    if (setting1 && setting2) {
        lastSync = [setting1.lastDateSentToServer compare:setting2.lastDateSentToServer] == NSOrderedAscending ? setting1.lastDateSentToServer : setting2.lastDateSentToServer;
    }
    else if (setting1){
        lastSync = setting1.lastDateSentToServer;
    }
    else{
        lastSync = setting2.lastDateSentToServer;
    }
    
    if (!lastSync || [[NSDate date] timeIntervalSinceDate:lastSync] >= INTERVAL_TIME_SYNC_SERVER) {
        [self sendDataToServer];
        timerSyncServer = [NSTimer scheduledTimerWithTimeInterval:INTERVAL_TIME_SYNC_SERVER target:self selector:@selector(sendDataToServer) userInfo:nil repeats:YES];
    }
    else{
        NSDate *nextTime = [lastSync dateByAddingTimeInterval:INTERVAL_TIME_SYNC_SERVER];
        [self performSelector:@selector(startSyncDataToServer) withObject:nil afterDelay:[nextTime timeIntervalSinceDate:[NSDate date]]];
    }
}

- (void)stopSyncDataToServer{
    if (timerSyncServer) {
        [timerSyncServer invalidate];
    }
}

- (void)sendDataToServer{
    if (PHRAppDelegate.isReadingHealthKit) {
      return;
    }
  
    // Check network
    if (PHRAppDelegate.networkStatus == NotReachable
        || (PHRAppDelegate.networkStatus == ReachableViaWWAN && ![HealthKitManager allowSyncOn3G])){
        
        DLog(@"BLACK BLACK BLACK -> not allow sync");
        return;
    }
    // Send to PHR Cloud
    RLMRealm *realm = [StorageManager realm];
    // ----- Standard
    if ([PHRAppStatus checkCurrentStandardActive]) {
        RLMResults *standard = [PHRSample objectsInRealm:realm where:@"profile_id == %@ AND synced == 0", PHRAppStatus.currentStandard.profileId];
     
        if (standard.count > 0) {
          
          NSMutableArray *array = [NSMutableArray array];
          for (RLMObject *object in standard) {
            [array addObject:object];
          }
          
          NSInteger limit;
          if (array.count > 7000) {
            limit = 7000;
          }else{
            limit = array.count;
          }
       
          int j = 0;
          while(limit) {
            NSRange range = NSMakeRange(j, MIN(500, limit));
            NSArray *subarray = [array subarrayWithRange:range];
            limit -= range.length;
            j += range.length;

            [self sendArraySamples:subarray profileId:PHRAppStatus.currentStandard.profileId isBaby:NO];
            
          }
        }
    }
    
    // ----- Baby
//    if ([PHRAppStatus checkCurrentBabyActive]) {
//        RLMResults *baby = [PHRSample objectsInRealm:realm where:@"profile_id == %@ AND synced == 0", PHRAppStatus.currentBaby.profileId];
//        if (baby.count > 0) {
//            [self sendArraySamples:baby profileId:PHRAppStatus.currentBaby.profileId isBaby:YES];
//        }
//    }
}

- (void)sendArraySamples:(NSArray*)results profileId:(NSString*)profileId isBaby:(BOOL)isBaby{
    PHRAppStatus.canShowAlert = YES;
  
#if !TARGET_OS_SIMULATOR
    [[UIDevice currentDevice] setBatteryMonitoringEnabled:YES];
    UIDevice *myDevice = [UIDevice currentDevice];
    
    [myDevice setBatteryMonitoringEnabled:YES];
    double batLeft = (float)[myDevice batteryLevel] * 100;
    if (batLeft < 20.0) {
        return;
    }
#endif
    [self performAction:^(){

      RLMRealm *realm = [StorageManager realm];
      NSString * UUID = [[UIDevice currentDevice] identifierForVendor].UUIDString;
      NSMutableDictionary *dict = [[NSMutableDictionary alloc] init];

      [realm beginWriteTransaction];

        //__block int numberOfFinishRequest = 0;
        //int numberOfType = 0;
        for (PHRSample *sample in results) {
            // sample.synced = 1;
            NSMutableArray *arr = nil;
            if (!dict[sample.type]) {
                arr = [[NSMutableArray alloc] initWithObjects:sample, nil];
                //numberOfType++;
            }
            else{
                arr = dict[sample.type];
                [arr addObject:sample];
            }
          dict[sample.type] = arr;
        }
        [realm commitWriteTransaction];
  
        __weak __typeof__(self) weakSelf = self;
        for (NSString *type in dict.allKeys ) {
            __typeof__(self) strongSelf = weakSelf;
            NSString *serverType = [PHRSample serverTypeForType:type];
            NSArray *arraySampleWithType = dict[type];

            if([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]){
                [strongSelf requestSyncListStandardLifeStyle:arraySampleWithType withProfileID:profileId type:nil andUDID:UUID completion:^{
                    [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                } error:^{
                    //do nothing
                }];
            }
            else if([type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning]
                    || [type isEqualToString:HKQuantityTypeIdentifierStepCount]){
                [strongSelf requestSyncListStandardFitness:arraySampleWithType withProfileID:profileId type:serverType andUDID:UUID completion:^{
                    [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                } error:^{
                    //do nothing
                }];
            }
            else if([type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates]
                    || [type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal]
                    || [type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed]){
                [strongSelf requestSyncListStandardFood:arraySampleWithType withProfileID:profileId type:serverType andUDID:UUID completion:^{
                    [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                } error:^{
                    //do nothing
                }];
            }
            else if([type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate]
                    || [type isEqualToString:HKQuantityTypeIdentifierHeartRate]
                    || [type isEqualToString:HKQuantityTypeIdentifierBodyTemperature]
                    || [type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic] /* key Sitolic return same data */){
                
                [strongSelf requestSyncListStandardTemperature:arraySampleWithType withProfileID:profileId type:serverType andUDID:UUID completion:^{
                    [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                } error:^{
                    // do nothing
                }];
            }
            else if([type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]
                    || [type isEqualToString:HKQuantityTypeIdentifierBodyMass]
                    || [type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]
                    || [type isEqualToString:HKQuantityTypeIdentifierHeight]){
                if (!isBaby) {
                    [strongSelf requestSyncListBodyMeasurement:arraySampleWithType withProfileID:profileId andUDID:UUID completion:^{
                        [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                    } error:^{
                        //do nothing
                    }];
                }
                else {
                    [strongSelf requestSyncListBabyGrowth:arraySampleWithType withProfileID:profileId type:serverType andUDID:UUID completion:^{
                        [strongSelf commitDataChanged:arraySampleWithType andRealm:realm];
                    } error:^{
                        //do nothing
                        
                    }];
                }
            }
        }
    }
              completed:nil]; 
}

- (void)commitDataChanged:(NSArray*)array andRealm:(RLMRealm*)realm {
    [realm beginWriteTransaction];
    [realm deleteObjects:array];
    [realm commitWriteTransaction];
}

- (void)writeHealthKit{
    if (![HealthKitManager allowWrite]) {
        DLog(@"BLACK BLACK BLACK -> not allow write to Healthkit");
        return;
    }
    [self performAction:^(){
        RLMRealm *realm = [StorageManager realm];
        [realm beginWriteTransaction];
        RLMResults<StorageSetting*> *settings = [StorageSetting objectsInRealm:realm where:@"profileId == %@", PHRAppStatus.masterProfileId];
        StorageSetting *setting = nil;
        if (settings.count > 0) {
            setting = settings[0];
        }
        else{
            setting = [StorageSetting settingProfile:PHRAppStatus.masterProfileId];
            [realm addObject:setting];
        }
        RLMResults *results = [PHRSample objectsInRealm:realm where:@"profile_id == %@ AND wrote == 1", PHRAppStatus.masterProfileId];
        results = [results objectsWhere:@"source_bundle == %@ OR source_bundle == %@ OR source_bundle == %@", [PHRSample bundleBluetooth], [[NSBundle mainBundle] bundleIdentifier],[PHRSample bundle]];
        if (results.count > 0) {
            NSMutableDictionary *dict = [[NSMutableDictionary alloc] init];
            for (PHRSample *sample in results) {
                // change state
                sample.wrote = 0;
                
                // merge into dict
                NSMutableArray *arr = nil;
                if (!dict[sample.type]) {
                    arr = [[NSMutableArray alloc] initWithObjects:sample, nil];
                }
                else{
                    arr = dict[sample.type];
                    [arr addObject:sample];
                }
                dict[sample.type] = arr;
            }
            [[HealthKitManager sharedManager] writeDataToHealthKitWithType:dict withCompletion:^(BOOL success){
                
            }error:^(NSError *error){
                [self commitWriteTransaction];
            }];
        }
        [realm deleteObjects:results];
        [realm commitWriteTransaction];
        
    }completed:nil];
}

#pragma mark - Queue handle realm
- (void)performAction:(void(^)())action completed:(void(^)())completion{
    RLMRealm *myRealm = [StorageManager realm];
    __block RLMNotificationToken *token = [myRealm addNotificationBlock:^(NSString *note, RLMRealm * realm) {
        [token stop];
        // Completion Callback
        if (completion) {
            completion();
        }
        if (self.transactionBuffer.count > 0) {
            void(^action)() = self.transactionBuffer[0];
            [self.transactionBuffer removeObjectAtIndex:0];
            action();
        }
    }];
    [myRealm refresh];
    [myRealm transactionWithBlock:^{
        // Save Data
        if (action) {
            if (myRealm.inWriteTransaction) {
                [self.transactionBuffer addObject:action];
            }
            else{
                action();
            }
        }
    }];
}

- (void)beginWriteTransaction{
    RLMRealm *realm = [StorageManager realm];
    if (!realm.inWriteTransaction) {
        [realm beginWriteTransaction];
    }
}

- (void)commitWriteTransaction{
    RLMRealm *realm = [StorageManager realm];
    if (realm.inWriteTransaction) {
        [realm commitWriteTransaction];
    }
}

#pragma mark - Healthkit process
- (void)readHealthkitSamples:(NSArray*)samples type:(NSString*)type isNotifyNeeded:(BOOL) isNotifyNeeded withCompletion:(void(^)())completion {
  
    if (!PHRAppStatus.masterProfileId) {
      completion();
        return;
    }
   // [self performAction:^(){
        // Query and update the result in another thread
        RLMRealm *realm = [StorageManager realm];
        [self beginWriteTransaction];
        // Get storage setting
        StorageSetting *setting = nil;
        // Process setting
        RLMResults<StorageSetting*> *results = [StorageSetting objectsInRealm:realm where:@"profileId == %@", PHRAppStatus.masterProfileId];
        if (results.count > 0) {
            setting = results[0];
        }
        else{
            setting = [StorageSetting settingProfile:PHRAppStatus.masterProfileId];
            [realm addObject:setting];
        }
        // Read sample data
        NSDate *lastSync = nil;
        RLMResults<PHRSample*> *storage = [PHRSample objectsInRealm:realm where:@"profile_id == %@ AND source_bundle != %@ AND source_bundle != %@ AND source_bundle != %@", PHRAppStatus.masterProfileId, [[NSBundle mainBundle] bundleIdentifier], [PHRSample bundleBluetooth], [PHRSample bundlePHRServer]];
        for (id sample in samples) {
            // Check if data exist in storage -> next (case: healthkit add data in the future)
            RLMResults *check = [storage objectsWhere:@"uuid == %@", ((HKSample*)sample).UUID.UUIDString];
            if (check.count > 0) {
                continue;
            }
            PHRSample *obj = nil;
            if ([type isEqualToString:HKCategoryTypeIdentifierSleepAnalysis]) {
                obj = [[PHRSample alloc] initWithCategorySample:sample profileId:PHRAppStatus.masterProfileId]; // master profile id == account id
            } else if ([type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic]) {
                obj = [[PHRSample alloc] initWithHKCorrelation:sample profileId:PHRAppStatus.masterProfileId];
            } else {
                obj = [[PHRSample alloc] initWithQuantitySample:sample profileId:PHRAppStatus.masterProfileId]; // master profile id == account id
                
            }
          
              if(![obj.source_bundle isEqualToString:[PHRSample bundle]] &&
                 ![obj.source_bundle isEqualToString:[PHRSample bundleBluetooth]]
                && ![obj.source_bundle isEqualToString:[PHRSample bundlePHRServer]]) {
                [realm addObject:obj];
                lastSync = obj.record_date;
                NSLog(@"%@ - %f",obj.record_date,obj.value);
                // Notify new data
                if ([PHRAppStatus checkCurrentStandardIsMaster] && isNotifyNeeded) {
                    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyHealthkitData object:obj userInfo:nil];
                }
            }
        }
        if (lastSync) {
            DLog(@"BLACK BLACK BLACK ----> Start read data");
            // Save last sync date
            setting.lastDateReadHealthKit = [NSDate date];
            setting.maxIdHealthKit = maxIdHk;
        }
        completion();
        [self commitWriteTransaction];
        //dispatch_semaphore_wait(semaphore, DISPATCH_TIME_FOREVER);
//    } completed:^(){
//        DLog(@"BLACK BLACK BLACK ----> Read data completed");
//    }];
}



#pragma mark - Bluetooth process
// Save data to local
- (void)savePHRSampleManual:(PHRSample*)sample{
    [self saveSamples:@[sample] completed:^(){
        [self writeHealthKit];
    }];
}

- (void)savePHRSample:(PHRSample*)sample{
    [self.samplesBuffer addObject:sample];
}

- (void)saveSamplesBuffer{
    if (_samplesBuffer) {
        [self saveSamples:self.samplesBuffer completed:^(){
            
        }];
    }
}

- (void)saveSamples:(NSArray*)samples completed:(void(^)())completion{
    if (!samples || samples.count <= 0) {
        return;
    }
    [self performAction:^(){
        RLMRealm *realm = [StorageManager realm];
        [realm beginWriteTransaction];
        RLMResults<StorageSetting*> *results = [StorageSetting allObjectsInRealm:realm];
        // Get storage setting
        for (PHRSample *sample in samples) {
            if (sample.wrote == 1) {
                continue;
            }
            // Process setting
            StorageSetting *setting = nil;
            RLMResults *results2 = [results objectsWhere:@"profileId == %@", sample.profile_id];
            if (results2.count > 0) {
                setting = results2[0];
            }
            else{
                setting = [StorageSetting settingProfile:sample.profile_id];
                [realm addObject:setting];
            }
            // Write sample data
            sample.wrote = 1;
            [realm addObject:sample];
            // Save last sync date
            setting.lastDateSavedSample = sample.record_date;
            setting.maxIdBluetooth = maxIdBluetooth;
        }
        [realm commitWriteTransaction];
        [self.samplesBuffer removeAllObjects];
    }completed:^(){
        if (completion) {
            completion();
        }
    }];
}


#pragma mark - Setting
- (StorageSetting*)settingForProfile:(NSString*)profileId{
    RLMRealm *realm = [StorageManager realm];
    RLMResults<StorageSetting*> *results = [StorageSetting objectsInRealm:realm where:@"profileId == %@", profileId];
    if (results.count > 0) {
        return results[0];
    }
    return nil;
}

#pragma mark - Sync fuction
- (void)requestSyncListBodyMeasurement:(NSArray*) listSamples withProfileID:(NSString*)profileID andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock{
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *healthType;
        if ([sample.type isEqualToString:HKQuantityTypeIdentifierHeight]) {
            healthType = @"01";
        } else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass]) {
            healthType = @"02";
        }  else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage]) {
            healthType = @"04";
        } else if ([sample.type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex]) {
            healthType = @"03";
        }
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        NSDictionary *dictionary = @{KEY_datetime_record : strDate != nil ? strDate : @"",
                                     KEY_Height : [sample.type isEqualToString:HKQuantityTypeIdentifierHeight] ? @(sample.value).stringValue: @"",
                                     KEY_Weight : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass] ? @(sample.value).stringValue : @"",
                                     KEY_PercentageFat : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyFatPercentage] ? @(sample.value).stringValue : @"",
                                     KEY_BMI : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyMassIndex] ? @(sample.value).stringValue : @"",
                                     KEY_Note : @"",
                                     KEY_HEALTH_TYPE: healthType,
                                     KEY_Source : sample.source_bundle};
        [listDictionarySample addObject:dictionary];
    }
    //[PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeBodyMeasurement:listDictionarySample profileID: profileID uuid:udid andCompleted:^(id response) {
        //[PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
       // [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock) {
            errorBlock();
        }
    }];
}

- (void)requestSyncListStandardTemperature:(NSArray*) listSamples withProfileID:(NSString*)profileID type:(NSString*)type andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock{
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        NSDictionary *dictionary = @{KEY_datetime_record : strDate,
                                     KEY_TEMPERATURE : [sample.type isEqualToString:HKQuantityTypeIdentifierBodyTemperature] ? @(sample.value).stringValue: @"",
                                     KEY_HEART_RATE : [sample.type isEqualToString:HKQuantityTypeIdentifierHeartRate] ? @(sample.value).stringValue : @"",
                                     KEY_RESPIRATORY : [sample.type isEqualToString:HKQuantityTypeIdentifierRespiratoryRate] ? @(sample.value).stringValue : @"",
                                     KEY_LOW_BLOOD_PRESSURE : [sample.type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic] ? @(sample.value2).stringValue : @"",
                                     KEY_HIGH_BLOOD_PRESSURE : [sample.type isEqualToString:HKQuantityTypeIdentifierBloodPressureDiastolic] ? @(sample.value).stringValue : @"",
                                     KEY_Note : @"",
                                     KEY_Source : sample.source_bundle
                                     };
        [listDictionarySample addObject:dictionary];
        DLog(@"Type:%@",type);
    }
   // [PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeTemperature:listDictionarySample profileID: profileID type:type uuid:udid andCompleted:^(id response) {
        [PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
//        [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock) {
            errorBlock();
        }
    }];
}

- (void)requestSyncListStandardFood:(NSArray*) listSamples withProfileID:(NSString*)profileID type:(NSString*)type andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock{
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        NSDictionary *dictionary = @{KEY_Eating_Time : strDate,
                                     KEY_Calories : [sample.type isEqualToString:HKQuantityTypeIdentifierDietaryEnergyConsumed] ? @(sample.value).stringValue: @"",
                                     KEY_Carbohydrate : [sample.type isEqualToString:HKQuantityTypeIdentifierDietaryCarbohydrates] ? @(sample.value).stringValue : @"",
                                     KEY_Total_Fat : [sample.type isEqualToString:HKQuantityTypeIdentifierDietaryFatTotal] ? @(sample.value).stringValue : @"",
                                     KEY_Rating_Satisfied : @"1",
                                     KEY_Note : @"",
                                     KEY_Source : sample.source_bundle
                                     };
        [listDictionarySample addObject:dictionary];
    }
    //[PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeStandardFood:listDictionarySample profileID: profileID type:type uuid:udid andCompleted:^(id response) {
       // [PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
//        [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock) {
            errorBlock();
        }
    }];
}

- (void)requestSyncListStandardLifeStyle:(NSArray*) listSamples withProfileID:(NSString*)profileID type:(NSString*)type andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock{
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        NSString *strDateWakeUp = [UIUtils stringUTCFromDateTime:[NSDate dateWithTimeInterval:sample.value * 3600 sinceDate:sample.record_date]];
        NSLog(@"%@ - %@ - %@",strDate, strDateWakeUp,@(sample.value).stringValue);
        NSDictionary *dictionary = @{KEY_LifeStyleNote_Time_Sleep : strDate,
                                     KEY_LifeStyleNote_Time_WakeUp : strDateWakeUp,
                                     KEY_LifeStyleNote_Total_time :  @(sample.value * 3600).stringValue,
                                     KEY_LifeStyleNote_Rating_Sleep : @"0",
                                     KEY_LifeStyleNote_Time_Awake : @"0",
                                     KEY_Source : sample.source_bundle
                                     };
        [listDictionarySample addObject:dictionary];
    }
    //[PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeStandardLifeStyle:listDictionarySample profileID: profileID uuid:udid andCompleted:^(id response) {
       // [PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
//        [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock){
            errorBlock();
        }
    }];
}

- (void)requestSyncListStandardFitness:(NSArray*) listSamples withProfileID:(NSString*)profileID type:(NSString*)type andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock{
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        
        DLog(@"BLACK BLACK BLACK => fitness source = %@", sample.source_bundle);
        NSLog(@"date:::: %@",strDate);
        NSDictionary *dictionary = @{KEY_DateRecord : strDate,
                                     KEY_Step_Count : [sample.type isEqualToString:HKQuantityTypeIdentifierStepCount] ? @(sample.value).stringValue: @"",
                                     KEY_Walking_Run :  [sample.type isEqualToString:HKQuantityTypeIdentifierDistanceWalkingRunning] ? @(sample.value).stringValue: @"",
                                     KEY_Source : sample.source_bundle
                                     };
        [listDictionarySample addObject:dictionary];
    }
   // [PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeStandardFitness:listDictionarySample profileID: profileID type:type uuid:udid andCompleted:^(id response) {
     //   [PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
//        [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock) {
            errorBlock();
        }
    }];
}

- (void)requestSyncListBabyGrowth:(NSArray*) listSamples withProfileID:(NSString*)profileID type:(NSString*)type andUDID:(NSString*) udid completion:(void(^)(void)) completionBlock error:(void(^)(void)) errorBlock {
    NSMutableArray *listDictionarySample = [[NSMutableArray alloc] init];
    for (int i = 0; i < listSamples.count; i++){
        PHRSample *sample = listSamples[i];
        NSString *strDate = [UIUtils stringUTCFromDateTime:sample.record_date];
        
        NSDictionary *dictionary = @{KEY_DateRecord : strDate,
                                     KEY_Height : [sample.type isEqualToString:HKQuantityTypeIdentifierHeight] ? @(sample.value).stringValue: @"",
                                     KEY_Weight :  [sample.type isEqualToString:HKQuantityTypeIdentifierBodyMass] ? @(sample.value).stringValue: @"",
                                     KEY_Source : sample.source_bundle
                                     };
        [listDictionarySample addObject:dictionary];
    }
   // [PHRAppDelegate showLoading];
    [[PHRClient instance] requestSynchronizeBabyGrowth:listDictionarySample profileID: profileID type:type uuid:udid andCompleted:^(id response) {
        //[PHRAppDelegate hideLoading];
        if (completionBlock) {
            completionBlock();
        }
    } error:^(NSString *error) {
//        [PHRAppDelegate hideLoading];
//        if (![NSUtils hasAlertViewOnWindow] && PHRAppStatus.canShowAlert) {
//            PHRAppStatus.canShowAlert = NO;
//            [NSUtils showMessage:kLocalizedString(error) withTitle:APP_NAME];
//        }
        if (errorBlock) {
            errorBlock();
        }
    }];
}

#pragma mark - MERGE storage data & server data
- (NSArray*)getSamplesUnsyncForType:(NSString*)type profileId:(NSString*)profileId{
  if (PHRAppDelegate.isReadingHealthKit) {
    return [NSArray new];
  }
  dispatch_queue_t exampleQueue = dispatch_queue_create("background", 0);

  NSMutableArray *array = [[NSMutableArray alloc] init];
  
  dispatch_sync(exampleQueue, ^{
    
    RLMRealm *realm = [StorageManager realm];
    RLMResults *results = [[PHRSample objectsInRealm:realm where:@"profile_id == %@ AND type == %@ AND synced == 0", profileId, type] sortedResultsUsingProperty:@"record_date" ascending:NSOrderedAscending];
    
    for (PHRSample *sample in results) {
        [array addObject:sample];
    }
    for (PHRSample *sample in self.samplesBuffer) {
        if ([sample.profile_id isEqualToString:profileId] && [sample.type isEqualToString:type]) {
            [array addObject:sample];
        }
    }
  });
     return [NSArray arrayWithArray:array];
 
}



@end
