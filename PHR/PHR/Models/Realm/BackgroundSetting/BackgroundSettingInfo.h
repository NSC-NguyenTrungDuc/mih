//
//  BackgroundSettingInfo.h
//  PHR
//
//  Created by NextopHN on 3/24/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface BackgroundSettingInfo : RLMObject
@property NSInteger Id;

@property NSString *imageNameBaby;
@property NSString *imageNameStandard;
@property NSString *userID;

@property BOOL isStorageStandard;
@property BOOL isStorageBaby;

@property int standardImageSelectedIndex;
@property int babyImageSelectedIndex;
@end

// This protocol enables typed collections. i.e.:
// RLMArray<BackgroundSettingInfo>
RLM_ARRAY_TYPE(BackgroundSettingInfo)
