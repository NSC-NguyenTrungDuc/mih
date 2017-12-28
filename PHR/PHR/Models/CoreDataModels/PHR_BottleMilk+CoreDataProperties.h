//
//  PHR_BottleMilk+CoreDataProperties.h
//  PHR
//
//  Created by DEV-MinhNN on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//
//  Choose "Create NSManagedObject Subclass…" from the Core Data editor menu
//  to delete and recreate this implementation file for your updated model.
//

#import "PHR_BottleMilk.h"

NS_ASSUME_NONNULL_BEGIN

@interface PHR_BottleMilk (CoreDataProperties)

@property (nullable, nonatomic, retain) NSDate *dateTime;
@property (nullable, nonatomic, retain) NSNumber *kcal;
@property (nullable, nonatomic, retain) NSString *milkType;
@property (nullable, nonatomic, retain) NSNumber *volume;

@end

NS_ASSUME_NONNULL_END
