//
//  EMRApiKey.h
//  PHR
//
//  Created by NextopHN on 4/14/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#ifndef EMRApiKey_h
#define EMRApiKey_h
// Profile
static NSString * const KEY_progressCourseValue         = @"progressCourse";
static NSString * const KEY_DiseasesValue               = @"registeredDiagnosis";

static NSString * const API_GetDetailProgressCourseXML  = @"api/emr/get?patient_code=%@&hosp_code=%@&format=xml";
static NSString * const API_GetFileEMR                  = @"/%@/%@/%@";
static NSString * const KEY_ProgressCourseModule        = @"ProgressCourseModule";
static NSString * const KEY_structuredExpression        = @"structuredExpression";
static NSString * const KEY_problemItem                 = @"problemItem";
static NSString * const KEY_docInfo                     = @"docInfo";
static NSString * const KEY_confirmDate                 = @"confirmDate";
static NSString * const KEY_contentModuleType           = @"contentModuleType";
// Medicine List
static NSString * const KEY_OC           = @"0C";
static NSString * const KEY_OD           = @"0D";
// key path
static NSString * const KEY_EMR_Tag                         = @"emr_tag";
static NSString * const KEY_EMR_Tag_Code                    = @"tag_code";
static NSString * const KEY_EMR_Tag_Name                    = @"tag_name";
static NSString * const KEYPath_GetMmlModuleItem            = @"Mml.MmlBody.MmlModuleItem";
static NSString * const KEYPath_GetMmlProblemItem           = @"content.ProgressCourseModule.structuredExpression.problemItem";
static NSString * const KEYPath_GetMmlSubjectiveItem        = @"subjective.subjectiveItem";
static NSString * const KEYPath_GetMmlSubjectiveItem_eventExpression        = @"subjective.subjectiveItem.eventExpression";
static NSString * const KEYPath_GetMmlObjectiveItem         = @"objective.objectiveNotes";
static NSString * const KEYPath_GetMmlAssessmentItem        = @"assessment.assessmentItem";
static NSString * const KEYPath_GetMmlAssessmentItemText        = @"assessment.assessmentItem.__text";
static NSString * const KEYPath_GetMmlPlanNotes             = @"plan.planNotes";
static NSString * const KEYPath_GetMmlListOrders             = @"plan.txOrder.Orders.Order";
static NSString * const KEYPath_GetMmlConfirmDate           = @"docInfo.confirmDate";
static NSString * const KEYPath_GetMmlContentModuleType     = @"docInfo.contentModuleType";
static NSString * const KEYPath_GetMmlContentRegisteredDiagnosis     = @"content";

static NSString * const KEYPath_GetMmlObjectiveItemPermission         = @"objective.mmlPc:permission";
static NSString * const KEYPath_GetMmlSubjectiveItemPermission        = @"subjective.subjectiveItem.mmlPc:permission";
static NSString * const KEYPath_GetMmlPlanNotesPermission             = @"plan.mmlPc:permission";
static NSString * const KEYPath_GetMmlAssessmentItemPermission        = @"assessment.assessmentItem.mmlPc:permission";


// MML progress course key
static NSString * const MML_problem=@"problem";
static NSString * const MML_subjective=@"subjective"; //+
static NSString * const MML_freeNotes=@"freeNotes";
static NSString * const MML_subjectiveItem=@"subjectiveItem";
static NSString * const MML_objective=@"objective";//+
static NSString * const MML_objectiveNotes=@"objectiveNotes";
static NSString * const MML_physicalExam=@"physicalExam";//+
static NSString * const MML_physicalExamItem=@"physicalExamItem";
static NSString * const MML_testResult=@"testResult";
static NSString * const MML_rxRecord=@"rxRecord";
static NSString * const MML_txRecord=@"txRecord";
static NSString * const MML_assessment=@"assessment";//+
static NSString * const MML_assessmentItem=@"assessmentItem";
static NSString * const MML_plan=@"plan"; //+
static NSString * const MML_testOrder=@"testOrder";
static NSString * const MML_rxOrder=@"rxOrder";
static NSString * const MML_txOrder=@"txOrder";
static NSString * const MML_planNotes=@"planNotes";
static NSString * const MML_Orders=@"Orders";
static NSString * const MML_Order=@"Order";


//PROD: http://emrfile.karte.clinic:8010/download
//UAT: http://117.6.172.189:8010/download
///dev/media.nextop.asia/:id_hosp_code/:id_patient_code/:id_file_name.extension
#endif /* EMRApiKey_h */
