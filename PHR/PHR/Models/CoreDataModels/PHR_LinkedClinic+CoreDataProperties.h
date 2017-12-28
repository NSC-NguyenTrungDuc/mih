//
//  PHR_LinkedClinic+CoreDataProperties.h
//  PHR
//
//  Created by DEV-MinhNN on 10/15/15.
//  Copyright © 2015 Sofia. All rights reserved.
//
//  Choose "Create NSManagedObject Subclass…" from the Core Data editor menu
//  to delete and recreate this implementation file for your updated model.
//

#import "PHR_LinkedClinic.h"

NS_ASSUME_NONNULL_BEGIN

@interface PHR_LinkedClinic (CoreDataProperties)

@property (nullable, nonatomic, retain) NSString *username;
@property (nullable, nonatomic, retain) NSString *password;

@end

NS_ASSUME_NONNULL_END
