//
//  PHR_User+CoreDataProperties.h
//  PHR
//
//  Created by DEV-MinhNN on 10/13/15.
//  Copyright © 2015 Sofia. All rights reserved.
//
//  Choose "Create NSManagedObject Subclass…" from the Core Data editor menu
//  to delete and recreate this implementation file for your updated model.
//

#import "PHR_User.h"

NS_ASSUME_NONNULL_BEGIN

@interface PHR_User (CoreDataProperties)

@property (nullable, nonatomic, retain) NSString *password;
@property (nullable, nonatomic, retain) NSString *username;
@property (nullable, nonatomic, retain) NSSet<PHR_BottleMilk *> *bottleMilk;
@property (nullable, nonatomic, retain) NSSet<PHR_MotherMilk *> *motherMilk;

@end

@interface PHR_User (CoreDataGeneratedAccessors)

- (void)addBottleMilkObject:(PHR_BottleMilk *)value;
- (void)removeBottleMilkObject:(PHR_BottleMilk *)value;
- (void)addBottleMilk:(NSSet<PHR_BottleMilk *> *)values;
- (void)removeBottleMilk:(NSSet<PHR_BottleMilk *> *)values;

- (void)addMotherMilkObject:(PHR_MotherMilk *)value;
- (void)removeMotherMilkObject:(PHR_MotherMilk *)value;
- (void)addMotherMilk:(NSSet<PHR_MotherMilk *> *)values;
- (void)removeMotherMilk:(NSSet<PHR_MotherMilk *> *)values;

@end

NS_ASSUME_NONNULL_END
