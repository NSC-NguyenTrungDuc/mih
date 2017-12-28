//
//  DataManager.m
//  PHR
//
//  Created by DEV-MinhNN on 2/2/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "DataManager.h"
//#import "PHR_Medicine_Note.h"

@implementation DataManager

+ (DataManager *)sharedManager {
    static DataManager *_sharedClient = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        _sharedClient = [[DataManager alloc] init];
    });
    return _sharedClient;
}

+ (void)clearData {
    [Setting truncateAll];
}

- (NSArray *)findUserSettingWithUserName:(NSString *)username {
    NSLog(@"findUserSettingWithUserName = %@", username);
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"username == %@", username];
    NSFetchRequest *fetchRecent = [Setting requestAllWithPredicate:predicate];
    NSArray *list = [Setting executeFetchRequest:fetchRecent];
    
    if (!list) {
        list = [NSArray array];
    }
    return list;
}

- (Setting *)findSettingItemWithType:(NSInteger)type andUsername:(NSString *)username {
    NSPredicate *predicate = [NSPredicate predicateWithFormat:@"itemType == %d AND username == %@", (int)type, username];
    Setting *currentTerm = [Setting findFirstWithPredicate:predicate];
    return currentTerm;
}

#pragma mark - Methods Public

- (NSMutableArray *)getArrayDateForDieases:(NSArray *)list {
    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        DiseasesModel *model = [[DiseasesModel alloc] initWithDictionary:dict error:nil];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:model.datetime_record];
        NSString *stringDate = [UIUtils formatDateOppositeStyle:dateTime];
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:stringDate]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:stringDate];
            }
        }
        else {
            [arrayDateTime addObject:stringDate];
        }
    }
    return arrayDateTime;
}

- (NSMutableArray *)getArrayDieases:(NSArray *)list withArray:(NSMutableArray *)arrayDiesses{
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        DiseasesModel *model = [[DiseasesModel alloc] initWithDictionary:dict error:nil];
        [arrayDiesses addObject:model];
    }
    return arrayDiesses;
}

#pragma mark - Temperature


#pragma mark - Standard Food


- (NSMutableArray *)getArrayBabyFood:(NSArray *)list{
    NSMutableArray *arrayFood = [[NSMutableArray alloc] init];
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        BabyFoodModel *model = [[BabyFoodModel alloc] initWithDictionary:dict error:nil];
        [arrayFood addObject:model];
    }
    return arrayFood;
}



- (NSMutableArray *)getArrayDateForBabyFood:(NSArray *)list {
    NSMutableArray *arrayDateTime = [[NSMutableArray alloc] init];
    
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        BabyFoodModel *model = [[BabyFoodModel alloc] initWithDictionary:dict error:nil];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:model.eating_time];
        
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
            }
        }
        else {
            [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
        }
    }
    return arrayDateTime;
}

#pragma mark - Life Style Note

- (NSMutableArray *)getArrayLifeStyleNote:(NSMutableArray *)arrayLifeStyle and:(NSArray *)list {
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        LifeStyleNoteModel *model = [[LifeStyleNoteModel alloc] initWithDictionary:dict error:nil];
        [arrayLifeStyle addObject:model];
    }
    
    return arrayLifeStyle;
}

- (NSMutableArray *)getArrayDateForLifeStyleNote:(NSMutableArray *)arrayDateTime and:(NSArray *)list {
    
    for (int i = 0; i < list.count; i++) {
        NSDictionary *dict = [list objectAtIndex:i];
        LifeStyleNoteModel *model = [[LifeStyleNoteModel alloc] initWithDictionary:dict error:nil];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:model.time_start_sleep];
        
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
            }
        }
        else {
            [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
        }
    }
    return arrayDateTime;
}

- (NSMutableArray *)getArrayDateForLifeStyleNoteFromListTable:(NSMutableArray *)arrayDateTime and:(NSArray *)list {
    
    for (int i = 0; i < list.count; i++) {
        LifeStyleNoteModel *model = [list objectAtIndex:i];
        NSDate *dateTime = [UIUtils dateFromServerTimeString:model.time_start_sleep];
        
        if (arrayDateTime.count > 0) {
            BOOL isAdd = YES;
            for (NSString *objDate in arrayDateTime) {
                if ([objDate isEqualToString:[UIUtils formatDateOppositeStyle:dateTime]]) {
                    isAdd = NO;
                }
            }
            if (isAdd) {
                [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
            }
        }
        else {
            [arrayDateTime addObject:[UIUtils formatDateOppositeStyle:dateTime]];
        }
    }

    return arrayDateTime;
}

#pragma mark -

//- (void)saveMedicinesInCacheWithList:(NSArray *)medicines {
//    for(MedicineNote *objNote in medicines) {
//        PHR_Medicine_Note *currentNote = [self checkMedicineNoteExistInData:objNote];
//        if (currentNote) {
//            currentNote.name      = objNote.name;
//            currentNote.unit      = objNote.unit;
//            currentNote.time_take = objNote.time_take_medicine;
//            currentNote.pre_url   = objNote.prescription_url;
//            currentNote.note      = objNote.note;
//            currentNote.method    = objNote.method;
//            currentNote.dose      = objNote.dose;
//            currentNote.quantity  = [NSNumber numberWithInt:objNote.quantity];
//            currentNote.date      = objNote.date;
//            currentNote.noteId    = [NSNumber numberWithInt:objNote.medicine_note_id];
//            
//            [currentNote save];
//            
//            continue;
//        }
//        
//        PHR_Medicine_Note *cacheFile = [PHR_Medicine_Note MR_createEntity];
//        
//        cacheFile.name      = objNote.name;
//        cacheFile.unit      = objNote.unit;
//        cacheFile.time_take = objNote.time_take_medicine;
//        cacheFile.pre_url   = objNote.prescription_url;
//        cacheFile.note      = objNote.note;
//        cacheFile.method    = objNote.method;
//        cacheFile.dose      = objNote.dose;
//        cacheFile.quantity  = [NSNumber numberWithInt:objNote.quantity];
//        cacheFile.date      = objNote.date;
//        cacheFile.noteId    = [NSNumber numberWithInt:objNote.medicine_note_id];
//        
//        [cacheFile save];
//    }
//}
//
//- (PHR_Medicine_Note *)checkMedicineNoteExistInData:(MedicineNote *)medicineNote {
//    NSFetchRequest *fetchRecent = [PHR_Medicine_Note requestAll];
//    NSArray *list = [PHR_Medicine_Note MR_executeFetchRequest:fetchRecent];
//    PHR_Medicine_Note *currentNote = nil;
//    if (list.count > 0) {
//        for (PHR_Medicine_Note *objNote in list) {
//            if ([objNote.noteId intValue] == medicineNote.medicine_note_id) {
//                currentNote = objNote;
//            }
//        }
//    }
//    
//    return currentNote;
//}

@end
