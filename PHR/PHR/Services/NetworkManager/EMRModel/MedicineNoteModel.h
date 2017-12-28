//
//  MedicineNoteModel.h
//  PHR
//
//  Created by NextopHN on 5/23/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <JSONModel/JSONModel.h>

@interface MedicineNoteModel : JSONModel

@property (nonatomic, strong) NSString<Optional> *id;
@property (nonatomic, strong) NSString<Optional> *datetime_record;
@property (nonatomic, strong) NSString<Optional> *prescription_name;
@property (nonatomic, strong) NSString<Optional> *medicine_name;
@property (nonatomic, strong) NSString<Optional> *dose;
@property (nonatomic, strong) NSString<Optional> *unit_code;
@property (nonatomic, strong) NSString<Optional> *unit;
@property (nonatomic, strong) NSString<Optional> *frequency;
@property (nonatomic, strong) NSString<Optional> *days;
@property (nonatomic, strong) NSString<Optional> *dosage;
@property (nonatomic, strong) NSString<Optional> *medicine_method;
@property (nonatomic, strong) NSString<Optional> *neawon_key;
@property (nonatomic, strong) NSString<Optional> *hangmog_code;
@end

/*
 {
 "id": "3806",
 "datetime_record": "2016/05/21",
 "prescription_name": "101",
 "medicine_name": null,
 "dose": "1",
 "unit_code": "016",
 "unit": "錠",
 "frequency": "2",
 "days": null,
 "dosage": "１日２回　朝・夕食後",
 "medicine_method": "1",
 "neawon_key": "2458",
 "hangmog_code": "620516002"
 }
 */