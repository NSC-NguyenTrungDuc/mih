//
//  DataManager.h
//  PHR
//
//  Created by DEV-MinhNN on 2/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Setting+CoreDataProperties.h"

@interface DataManager : NSObject

+ (DataManager *)sharedManager;
+ (void)clearData;

- (NSArray *)findUserSettingWithUserName:(NSString *)username;
- (Setting *)findSettingItemWithType:(NSInteger)type andUsername:(NSString *)username;

- (NSMutableArray *)getArrayDateForDieases:(NSArray *)list;

- (NSMutableArray *)getArrayDateForLifeStyleNote:(NSMutableArray *)arrayDateTime and:(NSArray *)list;
- (NSMutableArray *)getArrayLifeStyleNote:(NSMutableArray *)arrayLifeStyle and:(NSArray *)list;
- (NSMutableArray *)getArrayDateForLifeStyleNoteFromListTable:(NSMutableArray *)arrayDateTime and:(NSArray *)list;

- (NSMutableArray *)getArrayBabyFood:(NSArray *)list;
- (NSMutableArray *)getArrayDateForBabyFood:(NSArray *)list;
- (NSMutableArray *)getArrayDieases:(NSArray *)list withArray:(NSMutableArray *)arrayDiesses;

@end
