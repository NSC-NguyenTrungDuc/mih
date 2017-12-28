//
//  StorageManager.h
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "PHRSample.h"
@class StorageSetting;
@interface StorageManager : NSObject{
    
}

+ (StorageManager*)instance;
+ (RLMRealm*)realm;

// Local saved
- (void)savePHRSampleManual:(PHRSample*)sample;
- (void)savePHRSample:(PHRSample*)sample;

// Setting & Read HK
- (StorageSetting*)settingForProfile:(NSString*)profileId;
- (void)readHealthkitSamples:(NSArray*)samples type:(NSString*)type isNotifyNeeded:(BOOL) isNotifyNeeded withCompletion:(void(^)())completion;

// Sync
- (void)startSyncDataToServer;
- (void)startSyncBluetoothAndPHRData;
- (void)stopSyncDataToServer;
- (void)stopSyncBluetoothAndPHRData;

#pragma mark - MERGE storage data & server data
- (NSArray*)getSamplesUnsyncForType:(NSString*)type profileId:(NSString*)profileId;

@end
