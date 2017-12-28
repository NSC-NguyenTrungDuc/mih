package nta.med.app.vertx.ihis;

import nta.med.core.infrastructure.SpringBeanFactory;
import nta.med.core.infrastructure.socket.vertx.AbstractVerticle;
import nta.med.service.ihis.handler.bass.*;
import nta.med.service.ihis.proto.BassServiceProto;

public class BassVerticle extends AbstractVerticle {

	public BassVerticle() {
		super(BassServiceProto.class, BassServiceProto.getDescriptor());
	}
	
	@Override
	protected void doStart() throws Exception {
		 //----[START] BAS0101U00 ------
		registerHandler(BassServiceProto.BAS0101U00ExecuteRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0101U00ExecuteHandler.class));
		registerHandler(BassServiceProto.BAS0101U00grdDetailRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0101U00grdDetailHandler.class));
		registerHandler(BassServiceProto.BAS0101U00grdMasterRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0101U00grdMasterHandler.class));
		registerHandler(BassServiceProto.BAS0101U00PrBasGridColumnChangedRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0101U00PrBasGridColumnChangedHandler.class));
		// ----[END]   BAS0101U00 ------
		// [START] [BAS0270U00] - Manage doctor code
		registerHandler(BassServiceProto.BAS0270U00FwkDoctorRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00FwkDoctorHandler.class));
		registerHandler(BassServiceProto.BAS0270U00FwkDoctorGradeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00FwkDoctorGradeHandler.class));
		registerHandler(BassServiceProto.BAS0270U00FwkGwaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00FwkGwaHandler.class));
		registerHandler(BassServiceProto.BAS0270U00GrdBAS0271Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00GrdBAS0271Handler.class));
		registerHandler(BassServiceProto.BAS0270U00GrdBAS0272Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00GrdBAS0272Handler.class));
		registerHandler(BassServiceProto.BAS0270U00LayDoctorNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00LayDoctorNameHandler.class));
		registerHandler(BassServiceProto.BAS0270U00LayDoctorGradeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00LayDoctorGradeHandler.class));
		registerHandler(BassServiceProto.BAS0270U00LayGwaRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00LayGwaHandler.class));
		registerHandler(BassServiceProto.BAS0270U00LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00LayDupCheckHandler.class));
		registerHandler(BassServiceProto.BAS0270U00ExecuteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0270U00ExecuteHandler.class));
		// [END] [BAS0270U00] - Manage doctor code

		// [START] [BAS0001U00] - Mannage hospital information
		registerHandler(BassServiceProto.BAS0001U00ControlDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00ControlDataValidatingHandler.class));
		registerHandler(BassServiceProto.BAS0001U00FbxDodobuHyeunFindClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00FbxDodobuHyeunFindClickHandler.class));
		registerHandler(BassServiceProto.BAS0001U00FbxDodobuHyeunDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00FbxDodobuHyeunDataValidatingHandler.class));
		registerHandler(BassServiceProto.BAS0001U00grdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00grdDetailHandler.class));
		registerHandler(BassServiceProto.BAS0001U00grdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00grdMasterHandler.class));
		registerHandler(BassServiceProto.BAS0001U00ExecuteRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00ExecuteHandler.class));
		registerHandler(BassServiceProto.BAS0001U00GrdBAS0001Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00GrdBAS0001Handler.class));
		registerHandler(BassServiceProto.BAS0001U00CboHospJinGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0001U00CboHospJinGubunHandler.class));
		// [END] [BAS0001U00] - Mannage hospital information
		
		// [START] [BAS0123U00] - Manage Zip code
		registerHandler(BassServiceProto.BAS0123U00FwkZipCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0123U00FwkZipCodeHandler.class));
		registerHandler(BassServiceProto.BAS0123U00GrdBAS0123Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0123U00GrdBAS0123Handler.class));
		registerHandler(BassServiceProto.BAS0123U00LayTonggyeCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0123U00LayTonggyeCodeHandler.class));
		registerHandler(BassServiceProto.BAS0123U00LayZipCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0123U00LayZipCodeHandler.class));
		registerHandler(BassServiceProto.BAS0123U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0123U00SaveLayoutHandler.class));
		// [END] [BAS0123U00] - Manage Zip code
		
		// [START] [BAS0210U00] - 
		registerHandler(BassServiceProto.BAS0210U00layDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00layDupCheckHandler.class));
		registerHandler(BassServiceProto.BAS0210U00DupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00DupCheckHandler.class));
		registerHandler(BassServiceProto.BAS0210U00grdBAS0210GridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00grdBAS0210GridColumnChangedHandler.class));
		registerHandler(BassServiceProto.BAS0210U00fbxDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00fbxDataValidatingHandler.class));
		registerHandler(BassServiceProto.BAS0210U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00SaveLayoutHandler.class));
		registerHandler(BassServiceProto.BAS0210U00fwkCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00fwkCommonHandler.class));
		registerHandler(BassServiceProto.BAS0210U00grdBAS0210Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0210U00grdBAS0210Handler.class));
		// [END] [BAS0210U00] -
		
		//[START]BAS0230U00-
		registerHandler(BassServiceProto.BAS0230U00GrdBas0230Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0230U00GrdBas0230Handler.class));
		registerHandler(BassServiceProto.BAS0230U00GrdBas0230SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0230U00GrdBas0230SaveLayoutHandler.class));
		//[END]BAS0230U00-
		
		// [START] - [BAS0260U00] - Manage dept code
		registerHandler(BassServiceProto.Bas0260U00grdBuseoInitRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U00grdBuseoInitHandler.class));
		registerHandler(BassServiceProto.Bas0260U00LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U00LayDupCheckHandler.class));
		registerHandler(BassServiceProto.Bas0260U00TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U00TransactionalHandler.class));
		registerHandler(BassServiceProto.Bas0260U00fwkBuseoGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U00fwkBuseoGubunHandler.class));
		registerHandler(BassServiceProto.Bas0260U00xEditGridCell19Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U00xEditGridCell19Handler.class));
		// [END] - [BAS0260U00] - Manage dept code
		
		//[START] [BAS0110U00] - Manage Insurers number
		registerHandler(BassServiceProto.BAS0110U00FwkCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00FwkCommonHandler.class));
		registerHandler(BassServiceProto.BAS0110U00GrdJohapRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00GrdJohapHandler.class));
		registerHandler(BassServiceProto.BAS0110U00getCodeNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00GetCodeNameHandler.class));
		registerHandler(BassServiceProto.BAS0110U00LayZipCode2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00LayZipCode2Handler.class));
		registerHandler(BassServiceProto.BAS0110U00GrdJohapGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00GrdJohapGubunHandler.class));
		registerHandler(BassServiceProto.BAS0110U00LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00LayDupCheckHandler.class));
		registerHandler(BassServiceProto.BAS0110U00TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110U00TransactionalHandler.class));
		// [END] [BAS0110U00] - Manage Insurers number
		
		// [START]IFS003U03
		registerHandler(BassServiceProto.IFS003U03TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS003U03TransactionalHandler.class));
		// [END]IFS003U03
		
		//[START] BAS0310U00
		registerHandler(BassServiceProto.BAS0310U00layGroupGubunCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00layGroupGubunCheckHandler.class));
		registerHandler(BassServiceProto.BAS0310U00PostLoadRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00PostLoadHandler.class));
		registerHandler(BassServiceProto.BAS0310U00MakeFindWorker2Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00MakeFindWorker2Handler.class));
		registerHandler(BassServiceProto.BAS0310U00MakeFindWorker3Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00MakeFindWorker3Handler.class));
		registerHandler(BassServiceProto.BAS0310U00MakeFindWorker4Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00MakeFindWorker4Handler.class));
		registerHandler(BassServiceProto.BAS0310U00MakeFindWorker5Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00MakeFindWorker5Handler.class));
		registerHandler(BassServiceProto.BAS0310U00MakeFindWorkerFbxMarumeGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00MakeFindWorkerFbxMarumeGubunHandler.class));
		registerHandler(BassServiceProto.BAS0310U00FbxBunCodeDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00FbxBunCodeDataValidatingHandler.class));
		registerHandler(BassServiceProto.BAS0310U00GrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00GrdListHandler.class));
		registerHandler(BassServiceProto.BAS0310U00TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310U00TransactionalHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdSaveLayRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdSaveLayHandler.class));
		//[END] BAS0310U00
		
		//[START] IFS0001U00
		registerHandler(BassServiceProto.IFS0001U00FindBoxInitRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00FindBoxInitHandler.class));
		registerHandler(BassServiceProto.IFS0001U00FindBoxRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00FindBoxHandler.class));
		registerHandler(BassServiceProto.IFS0001U00FindBoxValidateRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00FindBoxValidateHandler.class));
		registerHandler(BassServiceProto.IFS0001U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00GrdMasterHandler.class));
		registerHandler(BassServiceProto.IFS0001U00GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00GrdDetailHandler.class));
		registerHandler(BassServiceProto.IFS0001U00PrCheckDupRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00PrCheckDupHandler.class));
		registerHandler(BassServiceProto.IFS0001U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0001U00SaveLayoutHandler.class));
		//[END] IFS0001U00
		
		//[START] BAS0311Q01
		registerHandler(BassServiceProto.BAS0311Q01GrdBAS0311Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0311Q01GrdBAS0311Handler.class));
		//[END] BAS0311Q01
		
		//[START] BAS0101U04
		registerHandler(BassServiceProto.BAS0101U04GrdDetailRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0101U04GrdDetailHandler.class));
		registerHandler(BassServiceProto.BAS0101U04GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0101U04GrdMasterHandler.class));
		registerHandler(BassServiceProto.BAS0101U04SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0101U04SaveLayoutHandler.class));
		registerHandler(BassServiceProto.BAS0101U04GrdMasterGridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0101U04GrdMasterGridColumnChangedHandler.class));
		//[END] BAS0101U04
		
		//[START] IFS0003U01
		registerHandler(BassServiceProto.IFS0003U01FwkCommonRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01FwkCommonHandler.class));
		registerHandler(BassServiceProto.IFS0003U01GrdIFS0003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01GrdIFS0003Handler.class));
		registerHandler(BassServiceProto.IFS0003U01LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01LayDupCheckHandler.class));
		registerHandler(BassServiceProto.IFS0003U01FbxSearchGubunDataValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01FbxSearchGubunDataValidatingHandler.class));
		registerHandler(BassServiceProto.IFS0003U01GrdIFS0003GridFindClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01GrdIFS0003GridFindClickHandler.class));
		registerHandler(BassServiceProto.IFS0003U01GrdIFS0003GridColumnChangedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01GrdIFS0003GridColumnChangedHandler.class));
		registerHandler(BassServiceProto.IFS0003U01SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U01SaveLayoutHandler.class));
		//[START] IFS0003U01
		
		// [START] IFS0003U00
		registerHandler(BassServiceProto.IFS0003U00LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00LayDupCheckHandler.class));
		registerHandler(BassServiceProto.IFS0003U00FbxSearchGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00FbxSearchGubunHandler.class));
		registerHandler(BassServiceProto.IFS0003U00GridColumnChangeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00GridColumnChangeHandler.class));
		registerHandler(BassServiceProto.IFS0003U00GrdIFS0003Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00GrdIFS0003Handler.class));
		registerHandler(BassServiceProto.IFS0003U00GridFindClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00GridFindClickHandler.class));
		registerHandler(BassServiceProto.IFS0003U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0003U00SaveLayoutHandler.class));
		// [END] IFS0003U00
		
		// [START] IFS0004U01
		registerHandler(BassServiceProto.IFS0004U01TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0004U01TransactionalHandler.class));
		registerHandler(BassServiceProto.IFS0004U01grdDetailtRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0004U01grdDetailtHandler.class));
		registerHandler(BassServiceProto.IFS0004U01grdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(IFS0004U01grdMasterHandler.class));
		//[END] IFS0004U01
		
		// [START] COMBIZ
		registerHandler(BassServiceProto.ComBizLoadIFS0001InfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComBizLoadIFS0001InfoHandler.class));
		registerHandler(BassServiceProto.ComBizLoadIFS0002InfoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComBizLoadIFS0002InfoHandler.class));
		registerHandler(BassServiceProto.ComBizGetFindWorkerRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComBizGetFindWorkerHandler.class));
		registerHandler(BassServiceProto.ComBizLoadColumnCodeNameRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComBizLoadColumnCodeNameHandler.class));
		registerHandler(BassServiceProto.ComBizLoadComboDataSourceRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(ComBizLoadComboDataSourceHandler.class));
		// [END] COMBIZ
		
		//[START] BAS0110Q00
		registerHandler(BassServiceProto.BAS0110Q00GrdBAS0110Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0110Q00GrdBAS0110Handler.class));
		//[END] BAS0110Q00
		
		//[START] BAS0203U00
		registerHandler(BassServiceProto.BAS0203U00FwkBunCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00FwkBunCodeHandler.class));
		registerHandler(BassServiceProto.BAS0203U00FwkSymyaGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00FwkSymyaGubunHandler.class));
		registerHandler(BassServiceProto.BAS0203U00GrdBAS0203Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00GrdBAS0203Handler.class));
		registerHandler(BassServiceProto.BAS0203U00LayDupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00LayDupCheckHandler.class));
		registerHandler(BassServiceProto.BAS0203U00LaySgCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00LaySgCodeHandler.class));
		registerHandler(BassServiceProto.BAS0203U00CboYoilGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00CboYoilGubunHandler.class));
		registerHandler(BassServiceProto.BAS0203U00LaySymyaGubunRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00LaySymyaGubunHandler.class));
		registerHandler(BassServiceProto.BAS0203U00LayBunCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00LayBunCodeHandler.class));
		registerHandler(BassServiceProto.BAS0203U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0203U00SaveLayoutHandler.class));
		//[START] BAS0203U00
		
		//[START] BAS0311U00
		registerHandler(BassServiceProto.BAS0311U00GridListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0311U00GridListHandler.class));
		//[END] BAS0311U00
		
		// [START] BAS0111U00
		registerHandler(BassServiceProto.BAS0111U00GrdBas0111Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0111U00GrdBas0111Handler.class));
		registerHandler(BassServiceProto.BAS0111U00GrdMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0111U00GrdMasterHandler.class));
		registerHandler(BassServiceProto.BAS0111U00LayGetJohapRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0111U00LayGetJohapHandler.class));
		registerHandler(BassServiceProto.BAS0111U00VzvZipCodeRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0111U00VzvZipCodeHandler.class));
		registerHandler(BassServiceProto.BAS0111U00VzvJohapRequest.class.getSimpleName(), SpringBeanFactory.beanFactory.getBean(BAS0111U00VzvJohapHandler.class));
		registerHandler(BassServiceProto.BAS0111U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0111U00SaveLayoutHandler.class));
		//[END] BAS0111U00
		
		//[START] BAS0310P01
		registerHandler(BassServiceProto.BAS0310P01GrdDrugMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdDrugMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdGenDrgMapRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdGenDrgMapHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdGenDrgMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdGenDrgMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdJinryoMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdJinryoMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdJojeMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdJojeMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdSangMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdSangMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdSusikMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdSusikMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdTokuteiMasterRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdTokuteiMasterHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdYjCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdYjCodeHandler.class));
//		registerHandler(BassServiceProto.BAS0310P01GrdSaveLayRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdSaveLayHandler.class));
		registerHandler(BassServiceProto.BAS0310P01ProcessRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01ProcessHandler.class));
		registerHandler(BassServiceProto.BAS0310P01GrdDrgSakuraRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0310P01GrdDrgSakuraHandler.class));
		//[START] BAS0310P01
		
		//[START] BAS0212U00
		registerHandler(BassServiceProto.BAS0212U00ComboListItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00ComboListItemHandler.class));
		registerHandler(BassServiceProto.BAS0212U00ListItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00ListItemHandler.class));
		registerHandler(BassServiceProto.BAS0212U00TransactionalRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00TransactionalHandler.class));
		registerHandler(BassServiceProto.BAS0212U00fwkGongbiCodeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00fwkGongbiCodeHandler.class));
		registerHandler(BassServiceProto.BAS0212U00GrdItemRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00GrdItemHandler.class));
		registerHandler(BassServiceProto.BAS0212U00LaydupCheckRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0212U00LaydupCheckHandler.class));
		//[START] BAS0212U00
		
		//[START] HOTCODEMASTER
		registerHandler(BassServiceProto.HOTCODEMASTERGetGrdListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(HOTCODEMASTERGetGrdListHandler.class));
		registerHandler(BassServiceProto.HOTCODEMASTERSaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(HOTCODEMASTERSaveLayoutHandler.class));
		registerHandler(BassServiceProto.HOTCODEMASTERSaveOCS0103Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(HOTCODEMASTERSaveOCS0103Handler.class));
		//[END] HOTCODEMASTER
		registerHandler(BassServiceProto.BAS2015U00MasterDataRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS2015U00MasterDataHandler.class));
		
		//[BEGIN] KCCK API
		registerHandler(BassServiceProto.Bas0260GetDepartmentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260GetDepartmentHandler.class));
		registerHandler(BassServiceProto.Bas0260UpdateDepartmentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260UpdateDepartmentHandler.class));
		//[END] KCCK API
		
		//[BEGIN] KCCK API
		registerHandler(BassServiceProto.CreatePatientSurveyRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(CreatePatientSurveyInfoHandler.class));
		//[END] KCCK API

		//[BEGIN] BAS0206U00 - BAS0206U01
		registerHandler(BassServiceProto.LoadGrdBAS0260U01Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadGrdBAS0260U01Handler.class));
		registerHandler(BassServiceProto.Bas0260U01LoadDepartmentTypeRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bas0260U01LoadDepartmentTypeHandler.class));
		registerHandler(BassServiceProto.LoadCbxLanguageRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(LoadCbxLanguageHandler.class));
		registerHandler(BassServiceProto.SaveGrdBas0260U01Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(SaveGrdBas0260U01Handler.class));
		registerHandler(BassServiceProto.Bass0260U00DepartmentRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(Bass0260U00DepartmentHandler.class));
		//[END] BAS0206U00 - BAS0206U01
		
		//[BEGIN] MIH
		registerHandler(BassServiceProto.BAS0250U00CboListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00CboListHandler.class));
		registerHandler(BassServiceProto.BAS0250U00GrdBAS0253Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00GrdBAS0253Handler.class));
		registerHandler(BassServiceProto.BAS0250U00GrdHoCodeListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00GrdHoCodeListHandler.class));
		registerHandler(BassServiceProto.BAS0250U00FindboxFindClickRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00FindboxFindClickHandler.class));
		registerHandler(BassServiceProto.BAS0250U00FbxHoMainGwaValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00FbxHoMainGwaValidatingHandler.class));
		registerHandler(BassServiceProto.BAS0250U00SaveLayoutRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00SaveLayoutHandler.class));
		registerHandler(BassServiceProto.BAS0250U00FbxHoGradeValidatingRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250U00FbxHoGradeValidatingHandler.class));
		
		registerHandler(BassServiceProto.BAS0250Q00grdBAS0260Request.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00grdBAS0260Handler.class));
		registerHandler(BassServiceProto.BAS0250Q00grdHOBEDRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00grdHOBEDHandler.class));
		registerHandler(BassServiceProto.BAS0250Q00layBedStatusRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00layBedStatusHandler.class));
		registerHandler(BassServiceProto.BAS0250Q00layJaewonListRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00layJaewonListHandler.class));
		registerHandler(BassServiceProto.BAS0250Q00layReserBedRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00layReserBedHandler.class));
		registerHandler(BassServiceProto.BAS0250Q00layMaxBedNoRequest.class.getSimpleName(),SpringBeanFactory.beanFactory.getBean(BAS0250Q00layMaxBedNoHandler.class));
		//[END] MIH
	}

	@Override
	protected void doStop() throws Exception {

	}
}
	
