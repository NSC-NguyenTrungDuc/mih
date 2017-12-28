//
//  Setting+CoreDataProperties.h
//  PHR
//
//  Created by DEV-MinhNN on 2/24/16.
//  Copyright © 2016 Sofia. All rights reserved.
//
//  Choose "Create NSManagedObject Subclass…" from the Core Data editor menu
//  to delete and recreate this implementation file for your updated model.
//

#import "Setting.h"

NS_ASSUME_NONNULL_BEGIN

@interface Setting (CoreDataProperties)

@property (nullable, nonatomic, retain) NSString *username;
@property (nonatomic, assign) int64_t itemType;
@property (nonatomic, assign) BOOL display;

@end

NS_ASSUME_NONNULL_END
