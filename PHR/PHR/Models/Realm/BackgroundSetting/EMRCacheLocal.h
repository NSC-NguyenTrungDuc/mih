//
//  EMRCacheLocal.h
//  PHR
//
//  Created by NextopHN on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface EMRCacheLocal : RLMObject
@property NSInteger Id;
@property NSString *emrCacheContent;
@property NSString *version;
@end
// This protocol enables typed collections. i.e.:
// RLMArray<LocalStorageImage>
RLM_ARRAY_TYPE(EMRCacheLocal)