//
//  StorageSetting.h
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface StorageSetting : RLMObject{
    
}
@property (nonatomic, strong) NSString* profileId; // master profile id if healthkit
// Get from Healthkit
@property (nonatomic, assign) long maxIdHealthKit; // id generate
@property (nonatomic, strong) NSDate *lastDateReadHealthKit; // use to read data from healthkit

// Get from Bluetooth/PHR (add)
@property (nonatomic, assign) long maxIdBluetooth;
@property (nonatomic, strong) NSDate *lastDateSavedSample;

// Sent to Server/Healthkit
@property (nonatomic, strong) NSDate *lastDateSentToServer;


+ (StorageSetting*)settingProfile:(NSString*)profileId;
- (void)update:(void (^)(StorageSetting *instance))updateBlock;

@end
