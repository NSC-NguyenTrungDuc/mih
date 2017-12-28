//
//  PHR_Medicine_Note+CoreDataProperties.h
//  PHR
//
//  Created by DEV-MinhNN on 10/28/15.
//  Copyright © 2015 Sofia. All rights reserved.
//
//  Choose "Create NSManagedObject Subclass…" from the Core Data editor menu
//  to delete and recreate this implementation file for your updated model.
//

#import "PHR_Medicine_Note.h"

NS_ASSUME_NONNULL_BEGIN

@interface PHR_Medicine_Note (CoreDataProperties)

@property (nullable, nonatomic, retain) NSString *name;
@property (nullable, nonatomic, retain) NSString *unit;
@property (nullable, nonatomic, retain) NSString *time_take;
@property (nullable, nonatomic, retain) NSString *pre_url;
@property (nullable, nonatomic, retain) NSString *note;
@property (nullable, nonatomic, retain) NSString *method;
@property (nullable, nonatomic, retain) NSString *dose;
@property (nullable, nonatomic, retain) NSNumber *quantity;
@property (nullable, nonatomic, retain) NSString *date;
@property (nullable, nonatomic, retain) NSNumber *noteId;

@end

NS_ASSUME_NONNULL_END
