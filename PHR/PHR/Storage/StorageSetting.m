//
//  StorageSetting.m
//  PHR
//
//  Created by Luong Le Hoang on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StorageSetting.h"
#import "StorageManager.h"

@implementation StorageSetting {
    
}

+ (StorageSetting*)settingProfile:(NSString*)profileId{
    StorageSetting *setting = [[StorageSetting alloc] init];
    setting.maxIdBluetooth = setting.maxIdHealthKit = 0;
    setting.lastDateReadHealthKit = setting.lastDateSentToServer = nil;
    setting.profileId = profileId;
    return setting;
}

- (void)update:(void (^)(StorageSetting *instance))updateBlock
{
    dispatch_async(dispatch_get_global_queue(DISPATCH_QUEUE_PRIORITY_HIGH, 0), ^{
        RLMRealm *realm = [StorageManager realm];
        if(!realm.inWriteTransaction){
            [realm beginWriteTransaction];
        }
        updateBlock(self);
        if(realm.inWriteTransaction){
            [realm commitWriteTransaction];
        }
    });
}

@end
