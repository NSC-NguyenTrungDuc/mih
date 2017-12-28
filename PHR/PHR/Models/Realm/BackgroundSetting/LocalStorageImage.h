//
//  LocalStorageImage.h
//  PHR
//
//  Created by NextopHN on 4/1/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Realm/Realm.h>

@interface LocalStorageImage : RLMObject
@property NSInteger Id;
@property NSData *imageData;
@property NSString *imageName;
@end

// This protocol enables typed collections. i.e.:
// RLMArray<LocalStorageImage>
RLM_ARRAY_TYPE(LocalStorageImage)
