//
//  Diaper.m
//  PHR
//
//  Created by DEV-MinhNN on 11/9/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Diaper.h"

@implementation Diaper

+ (NSArray *)arrayState {
    return @[kLocalizedString(kDiaperStateDry),
             kLocalizedString(kDiaperStateWet),
             kLocalizedString(kDiaperStateSolid)];
}

+ (Diaper *)initializeDiaperFrom:(NSDictionary *)dict {
    Diaper *objNote   = [Diaper new];
    NSDate *dayDiaper = [UIUtils dateFromServerTimeString:[dict objectForKey:KEY_BabyDiaper_Time]];

    objNote.diaperID        = [dict objectForKey:KEY_Id];
    objNote.dateTime        = [UIUtils formatDateOppositeStyle:dayDiaper];
    objNote.time_pee_poo    = [dict objectForKey:KEY_BabyDiaper_Time];
    objNote.alert           = [dict objectForKey:KEY_Alert];
    objNote.method          = [dict objectForKey:KEY_MedicineNote_Method];
    objNote.state           = [dict objectForKey:KEY_BabyDiaper_State];
    objNote.note            = [dict objectForKey:KEY_Note];
    objNote.color           = [dict objectForKey:KEY_BabyDiaper_Color];
    
    return objNote;
}

+ (Diaper *)initializeDiaperFromModel:(BabyDiaperModel *)model andDate:(NSString *)date {
    Diaper *objNote = [Diaper new];
    
    objNote.dateTime        = date;
    objNote.time_pee_poo    = model.time_pee_poo;
    objNote.alert           = model.alert;
    objNote.method          = model.method;
    objNote.state           = model.state;
    objNote.note            = model.note;
    objNote.color           = model.color;
    
    return objNote;
}

@end
