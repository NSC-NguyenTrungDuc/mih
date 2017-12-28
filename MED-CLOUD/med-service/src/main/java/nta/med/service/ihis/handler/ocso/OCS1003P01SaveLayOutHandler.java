package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.inv.Inv0001;
import nta.med.core.domain.inv.Inv1001;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.domain.ocs.Ocs1003C;
import nta.med.core.domain.out.Outsang;
import nta.med.core.glossary.DataRowState;
import nta.med.core.glossary.MonitorKey;
import nta.med.core.infrastructure.MonitorLog;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.inv.Inv0001Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.inv.Inv1001Repository;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs1003_TempRepository;
import nta.med.data.dao.medi.ocs.Ocs1003cRepository;
import nta.med.data.dao.medi.ocs.Ocs1023Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.data.dao.medi.out.OutsangRepository;
import nta.med.data.model.phr.SyncDrugInfo;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.ihis.proto.OcsoModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
@Transactional
public class OCS1003P01SaveLayOutHandler extends ScreenHandler<OcsoServiceProto.OCS1003P01SaveLayOutRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOG = LogFactory.getLog(OCS1003P01SaveLayOutHandler.class);
	
	@Resource
	private OutsangRepository outsangRepository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Ocs1023Repository ocs1023Repository;
	
	@Resource
	private Ocs1003_TempRepository ocs1003TempRepository;
	
	@Resource
	private Ocs1003cRepository ocs1003cRepository;
	
	@Resource
	private Out1001Repository out1001Repository;
	
	@Resource
	private Configuration configuration;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Inv0001Repository inv0001Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
    private Inv2003Repository inv2003Repository;
    
    @Resource
    private Inv2004Repository inv2004Repository;
    
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Resource
    private Inv4001Repository inv4001Repository;
    
    @Resource
    private Inv4002Repository inv4002Repository;
	
    @Resource
    private Inv0110Repository inv0110Repository;
    
    @Resource
    private Inv0102Repository inv0102Repository; 
    @Resource
    private Inv1001Repository inv1001Repository;
    
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OCS1003P01SaveLayOutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		String hospCode = getHospitalCode(vertx, sessionId);
		if(!StringUtils.isEmpty(request.getHospCodeLink())){
			hospCode = request.getHospCodeLink();
		}
		String language = getLanguage(vertx, sessionId);
		Integer localTimeZone = getTimeZone(vertx, sessionId);
		if(localTimeZone == null){
			List<Bas0001> bas0001List = bas0001Repository.findLatestByHospCode(hospCode);
			if (!CollectionUtils.isEmpty(bas0001List)) {
				Bas0001 bas0001 = bas0001List.get(0);
				localTimeZone = bas0001.getTimeZone() != null ? bas0001.getTimeZone() : configuration.getDefaultTimeZone();
			} else{
				localTimeZone = configuration.getDefaultTimeZone();
			}
		}
		
		response = saveLayOut(vertx, request, hospCode, language, localTimeZone, getUserId(vertx, sessionId));
    	if(!response.getResult()){
    		throw new ExecutionException(response.build());
    	}
    	
    	MonitorLog.writeMonitorLog(MonitorKey.REG_ORDER, "[MEDAPP]REG_ORDER : New order have been successfully registered");
		return response.build();
	}
	
	public SystemServiceProto.UpdateResponse.Builder saveLayOut(Vertx vertx, OcsoServiceProto.OCS1003P01SaveLayOutRequest request, String hospCode, String language, int localTimeZone, String userId){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<OcsoModelProto.OcsoOCS1003P01GridOutSangInfo> lstOutSang = request.getGrdOutSangListList();
		String patientCode = "";
		
		boolean invUsage = false;
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, "INV_USAGE");
		if(!CollectionUtils.isEmpty(bas0102List)){
			if("Y".equals(bas0102List.get(0).getCode())){
				invUsage = true;
			}
		}
		
		// [START] CREATE/UPDATE/DELETE OUTSANG
		if(lstOutSang != null && lstOutSang.size() > 0){
			patientCode = lstOutSang.get(0).getBunho();
			for(OcsoModelProto.OcsoOCS1003P01GridOutSangInfo outSangInfo : lstOutSang){
			List<Outsang> listInsertOutsang = new ArrayList<Outsang>();
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(outSangInfo.getDataRowState())){
					Double pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
					if(pkSeq == null){
						pkSeq = 1.0;
					}
					Double ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
					if(ser == null){
						ser = 1.0;
					}
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,outSangInfo.getIoGubun(), outSangInfo.getGwa(),
							outSangInfo.getBunho(), outSangInfo.getFkinp1001(), outSangInfo.getSangCode(),outSangInfo.getSangName(), outSangInfo.getPostModifierName(),
							outSangInfo.getPreModifierName(),outSangInfo.getSangStartDate(),outSangInfo.getSangEndDate(),outSangInfo.getSangJindanDate(),
							outSangInfo.getDataGubun(),outSangInfo.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
						return response;
					}
					Outsang outsang = new Outsang();
					
					outsang.setSysDate(new Date());
					outsang.setSysId(request.getUserId());
					outsang.setBunho(outSangInfo.getBunho());
					outsang.setHospCode(hospCode);
					outsang.setGwa(outSangInfo.getGwa());
					outsang.setIoGubun(outSangInfo.getIoGubun()); 
					outsang.setPkSeq(pkSeq);
					if(!outSangInfo.getNaewonDate().isEmpty() && DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setNaewonDate(DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
					}

					outsang.setDoctor(outSangInfo.getLastDoctor());
					outsang.setNaewonType(outSangInfo.getLastNaewonType());
					if(outSangInfo.getJubsuNo()!= null && !outSangInfo.getJubsuNo().isEmpty() ){
						outsang.setJubsuNo(CommonUtils.parseDouble(outSangInfo.getJubsuNo()));
					}
					if(outSangInfo.getNaewonDate() != null && !outSangInfo.getNaewonDate().isEmpty()){
						outsang.setLastNaewonDate (DateUtil.toDate(outSangInfo.getNaewonDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setLastDoctor(outSangInfo.getLastDoctor());
					outsang.setLastNaewonType(outSangInfo.getLastNaewonType());
					if(outSangInfo.getLastJubsuNo()!= null && !outSangInfo.getLastJubsuNo().isEmpty() ){
						outsang.setLastJubsuNo(CommonUtils.parseDouble(outSangInfo.getLastJubsuNo()));
					}
					if(outSangInfo.getFkinp1001()!= null && !outSangInfo.getFkinp1001().isEmpty() ){
						outsang.setFkinp1001(CommonUtils.parseDouble(outSangInfo.getFkinp1001()));
					}
					outsang.setInputId(request.getUserId());
					outsang.setSer(ser);
					outsang.setSangCode(outSangInfo.getSangCode());
					outsang.setJuSangYn(outSangInfo.getJuSangYn());
					outsang.setSangName (outSangInfo.getSangName());
					if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangStartDate (DateUtil.toDate(outSangInfo.getSangStartDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangEndDate (DateUtil.toDate(outSangInfo.getSangEndDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setSangEndSayu(outSangInfo.getSangEndSayu());
					outsang.setPreModifier1 (outSangInfo.getPreModifier1());
					outsang.setPreModifier2(outSangInfo.getPreModifier2());
					outsang.setPreModifier3(outSangInfo.getPreModifier3());
					outsang.setPreModifier4(outSangInfo.getPreModifier4());
					outsang.setPreModifier5 (outSangInfo.getPreModifier5());
					outsang.setPreModifier6(outSangInfo.getPreModifier6());
					outsang.setPreModifier7(outSangInfo.getPreModifier7());
					outsang.setPreModifier8(outSangInfo.getPreModifier8());
					outsang.setPreModifier9 (outSangInfo.getPreModifier9());
					outsang.setPreModifier10(outSangInfo.getPreModifier10());
					outsang.setPreModifierName(outSangInfo.getPreModifierName());
					outsang.setPostModifier1(outSangInfo.getPostModifier1());
					outsang.setPostModifier2(outSangInfo.getPostModifier2());
					outsang.setPostModifier3(outSangInfo.getPostModifier3());
					outsang.setPostModifier4(outSangInfo.getPostModifier4());
					outsang.setPostModifier5(outSangInfo.getPostModifier5());
					outsang.setPostModifier6(outSangInfo.getPostModifier6());
					outsang.setPostModifier7(outSangInfo.getPostModifier7());
					outsang.setPostModifier8(outSangInfo.getPostModifier8());
					outsang.setPostModifier9(outSangInfo.getPostModifier9());
					outsang.setPostModifier10(outSangInfo.getPostModifier10());
					outsang.setPostModifierName(outSangInfo.getPostModifierName());
					if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(),DateUtil.PATTERN_YYMMDD) != null){
						outsang.setSangJindanDate (DateUtil.toDate(outSangInfo.getSangJindanDate(),DateUtil.PATTERN_YYMMDD)); 
					}
					outsang.setDataGubun(outSangInfo.getDataGubun());
					listInsertOutsang.add(outsang);
					
					 //IF modified
				} else if (DataRowState.MODIFIED.getValue().equalsIgnoreCase(outSangInfo.getDataRowState())){
					Double pkoutsang = CommonUtils.parseDouble(outSangInfo.getPkoutsang());
					String retVal = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
					Double ser = 0.0;
					Double pkSeq = 0.0;
					if(outSangInfo.getSer() != null && !outSangInfo.getSer().isEmpty()){
						ser = CommonUtils.parseDouble(outSangInfo.getSer());
					}
					if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
						pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
					}
					
					if("%".equals(retVal)){
						pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
						if(pkSeq == null){
							pkSeq = 1.0;
						}
						ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
						if(ser == null){
							ser = 1.0;
						}
					}
					
					String resultSang = outsangRepository.getOUTSANGU00ResultSang(hospCode,outSangInfo.getIoGubun(), outSangInfo.getGwa(),
							outSangInfo.getBunho(), outSangInfo.getFkinp1001(), outSangInfo.getSangCode(),outSangInfo.getSangName(), outSangInfo.getPostModifierName(),
							outSangInfo.getPreModifierName(),outSangInfo.getSangStartDate(),outSangInfo.getSangEndDate(),outSangInfo.getSangJindanDate(),
							outSangInfo.getDataGubun(),outSangInfo.getJuSangYn());
					if(resultSang.equalsIgnoreCase("Y")){
						response.setResult(false);
						return response;
					}
					
					
					Date sangStartDate = new Date();
					Date sangEndDate = new Date();
					Date sangJindanDate = new Date();
					if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangStartDate = DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
					}
					
					if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangEndDate = DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
					}
					
					if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
						sangJindanDate = DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
					}
					
					outsangRepository.updateOUTSANGOU00Transaction(request.getUserId(), 
							ser, 
							outSangInfo.getSangName(), 
							sangStartDate, 
							sangEndDate, 
							outSangInfo.getSangEndSayu(), 
							outSangInfo.getJuSangYn(),
							outSangInfo.getPreModifier1(), 
							outSangInfo.getPreModifier2(), 
							outSangInfo.getPreModifier3(), 
							outSangInfo.getPreModifier4(), 
							outSangInfo.getPreModifier5(), 
							outSangInfo.getPreModifier6(), 
							outSangInfo.getPreModifier7(), 
							outSangInfo.getPreModifier8(), 
							outSangInfo.getPreModifier9(), 
							outSangInfo.getPreModifier10(), 
							outSangInfo.getPreModifierName(), 
							outSangInfo.getPostModifier1(), 
							outSangInfo.getPostModifier2(), 
							outSangInfo.getPostModifier3(), 
							outSangInfo.getPostModifier4(), 
							outSangInfo.getPostModifier5(), 
							outSangInfo.getPostModifier6(), 
							outSangInfo.getPostModifier7(), 
							outSangInfo.getPostModifier8(), 
							outSangInfo.getPostModifier9(), 
							outSangInfo.getPostModifier10(), 
							outSangInfo.getPostModifierName(), 
							sangJindanDate, 
							outSangInfo.getDataGubun(), 
							outSangInfo.getBunho(), 
							outSangInfo.getGwa(), 
							outSangInfo.getIoGubun(), 
							pkSeq, 
							hospCode);
				} else if (DataRowState.DELETED.getValue().equals(outSangInfo.getDataRowState())){
						String ifDataSendYn = outsangRepository.getIfDataSendYn(hospCode, outSangInfo.getBunho(), outSangInfo.getGwa(), outSangInfo.getIoGubun(), CommonUtils.parseDouble(outSangInfo.getPkSeq()));
						
						if(outSangInfo.getDataGubun().equalsIgnoreCase("I") && ifDataSendYn.equalsIgnoreCase("N")){
							Double pkSeq = 0.0;
							if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
								pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
							}
							outsangRepository.deleteOUTSANGU00Transaction(
									outSangInfo.getBunho(),
									outSangInfo.getGwa(),
									outSangInfo.getIoGubun(),
									pkSeq,
									hospCode);
						}else{
							Double pkoutsang = CommonUtils.parseDouble(outSangInfo.getPkoutsang());
							String retVal = outsangRepository.getOcsoOCS1003P01GetGwoFromOutsang(hospCode, pkoutsang);
							Double ser = 0.0;
							Double pkSeq = 0.0;
							if(outSangInfo.getSer() != null && !outSangInfo.getSer().isEmpty()){
								ser = CommonUtils.parseDouble(outSangInfo.getSer());
							}
							if(outSangInfo.getPkSeq() != null && !outSangInfo.getPkSeq().isEmpty()){
								pkSeq = CommonUtils.parseDouble(outSangInfo.getPkSeq());
							}
							
							if("%".equals(retVal)){
								pkSeq = outsangRepository.getOUTSANGU00PkSeq(hospCode,outSangInfo.getBunho(),outSangInfo.getGwa(),outSangInfo.getIoGubun());
								if(pkSeq == null){
									pkSeq = 1.0;
								}
								ser = outsangRepository.getOUTSANGU00Ser(hospCode, outSangInfo.getBunho());
								if(ser == null){
									ser = 1.0;
								}
							}
							
							Date sangStartDate = new Date();
							Date sangEndDate = new Date();
							Date sangJindanDate = new Date();
							if(!outSangInfo.getSangStartDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangStartDate = DateUtil.toDate(outSangInfo.getSangStartDate(), DateUtil.PATTERN_YYMMDD);
							}
							if(!outSangInfo.getSangEndDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangEndDate = DateUtil.toDate(outSangInfo.getSangEndDate(), DateUtil.PATTERN_YYMMDD);
							}
							if(!outSangInfo.getSangJindanDate().isEmpty() && DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD) != null){
								sangJindanDate = DateUtil.toDate(outSangInfo.getSangJindanDate(), DateUtil.PATTERN_YYMMDD);
							}
							outsangRepository.updateOUTSANGOU00Transaction(request.getUserId(), 
									ser, 
									outSangInfo.getSangName(), 
									sangStartDate, 
									sangEndDate, 
									outSangInfo.getSangEndSayu(), 
									outSangInfo.getJuSangYn(),
									outSangInfo.getPreModifier1(), 
									outSangInfo.getPreModifier2(), 
									outSangInfo.getPreModifier3(), 
									outSangInfo.getPreModifier4(), 
									outSangInfo.getPreModifier5(), 
									outSangInfo.getPreModifier6(), 
									outSangInfo.getPreModifier7(), 
									outSangInfo.getPreModifier8(), 
									outSangInfo.getPreModifier9(), 
									outSangInfo.getPreModifier10(), 
									outSangInfo.getPreModifierName(), 
									outSangInfo.getPostModifier1(), 
									outSangInfo.getPostModifier2(), 
									outSangInfo.getPostModifier3(), 
									outSangInfo.getPostModifier4(), 
									outSangInfo.getPostModifier5(), 
									outSangInfo.getPostModifier6(), 
									outSangInfo.getPostModifier7(), 
									outSangInfo.getPostModifier8(), 
									outSangInfo.getPostModifier9(), 
									outSangInfo.getPostModifier10(), 
									outSangInfo.getPostModifierName(), 
									sangJindanDate, 
									outSangInfo.getDataGubun(), 
									outSangInfo.getBunho(), 
									outSangInfo.getGwa(), 
									outSangInfo.getIoGubun(), 
									pkSeq, 
									hospCode);
						}
				}
				if(listInsertOutsang.size() > 0) {
					outsangRepository.save(listInsertOutsang);
				}
			}
		}
		// [END] CREATE/UPDATE/DELETE OUTSANG
		
		List<Ocs1003> listOcs1003Inserted = new ArrayList<Ocs1003>();
		
		// [START] DELETE OCS1003/OCS1003C
		List<OcsoModelProto.OCS1003P01LayDeletedDataListItemInfo> layDeleteDataList = request.getLayDeleteListList();
		if(layDeleteDataList != null && layDeleteDataList.size() > 0){
			for(OcsoModelProto.OCS1003P01LayDeletedDataListItemInfo layDeleteDataInfo: layDeleteDataList){
				Double sourcePkOcs = CommonUtils.parseDouble(layDeleteDataInfo.getSourceOrdKey());
	            String result = ocs1003Repository.callPrOcsUpdateDcYn(hospCode, "O", sourcePkOcs);
	            if("0".equals(result)){
	            	response.setResult(false);
	    			return response;
	            }else{
	            	Double pkocsDel = CommonUtils.parseDouble(layDeleteDataInfo.getPkocskey());
	            	ocs1003cRepository.deleteOcsoOCS1003P01DeleteFromOCS1003C(pkocsDel, hospCode);
	            	int delCount = ocs1003Repository.deleteOcsoOCS1003P01DeleteFromOCS1003(pkocsDel, hospCode);
	            	// fix bug 11480
	            	inv1001Repository.deleteINV1001ByFkocs1003(hospCode, pkocsDel);
					if(delCount > 0 && invUsage) inv0001Repository.setActiveInv0001(hospCode, pkocsDel, userId, new BigDecimal(0));
	            }
			}
		}
		// [END] DELETE OCS1003/OCS1003C
		
		// [START] INSERT/UPDATE OCS1003/OCS1003C
		List<OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo> saveLayoutList = request.getLaySaveListList();
		if(saveLayoutList != null && saveLayoutList.size() > 0 ){
			if(StringUtils.isEmpty(patientCode)){
				patientCode = saveLayoutList.get(0).getBunho();
			}
			
			for(OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo saveLayoutInfo : saveLayoutList){
				Double pkocs1003 = 1D;
				
				if(DataRowState.ADDED.getValue().equalsIgnoreCase(saveLayoutInfo.getRowState())){
					if("N".equalsIgnoreCase(saveLayoutInfo.getActionDoYn())){
						Ocs1003C ocs1003c =  insertOcs1003C(saveLayoutInfo, hospCode, request.getUserId(), localTimeZone);
						pkocs1003 = ocs1003c.getPkocs1003c();
					} else {
						Boolean isDuplicateKey = ocs1003Repository.isExistedOCS1003(hospCode, CommonUtils.parseDouble(saveLayoutInfo.getPkocskey()));
						if (isDuplicateKey) {
							response.setResult(false);
							response.setMsg("duplicate");
							LOG.info("OCS1003P01SaveLayOutHandler Duplicate entry hospCode: " + hospCode + ", pkocs1003: " + saveLayoutInfo.getPkocskey());
						} else {
							Ocs1003 ocs1003 = insertOcs1003(saveLayoutInfo, hospCode, request.getUserId(), localTimeZone);
							pkocs1003 = ocs1003.getPkocs1003();
							listOcs1003Inserted.add(ocs1003);
						}
					}
					// fix bug 11480 
					if(!StringUtils.isEmpty(saveLayoutInfo.getBomSourceKey())){
						Double pkinv1001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV1001_SEQ"));
						insertINV1001(saveLayoutInfo, userId, pkinv1001, pkocs1003, hospCode);
					}
					
				}else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(saveLayoutInfo.getRowState())){
					if(StringUtils.isEmpty(saveLayoutInfo.getPkocskey())){
						response.setResult(false);
						return response;
					}
					
					Double suryang = CommonUtils.parseDouble(saveLayoutInfo.getSuryang());
					Double dv = CommonUtils.parseDouble(saveLayoutInfo.getDv());
					Double nalsu = CommonUtils.parseDouble(saveLayoutInfo.getNalsu());
					Date hopeDate = DateUtil.toDate(saveLayoutInfo.getHopeDate(), DateUtil.PATTERN_YYMMDD);
					Double dv1 = CommonUtils.parseDouble(saveLayoutInfo.getDv1());
					Double dv2 = CommonUtils.parseDouble(saveLayoutInfo.getDv2());
					Double dv3 = CommonUtils.parseDouble(saveLayoutInfo.getDv3());
					Double dv4 = CommonUtils.parseDouble(saveLayoutInfo.getDv4());
					Double dv5 = CommonUtils.parseDouble(saveLayoutInfo.getDv5());
					Double dv6 = CommonUtils.parseDouble(saveLayoutInfo.getDv6());
					Double dv7 = CommonUtils.parseDouble(saveLayoutInfo.getDv7());
					Double dv8 = CommonUtils.parseDouble(saveLayoutInfo.getDv8());
					Double bomSourceKey = CommonUtils.parseDouble(saveLayoutInfo.getBomSourceKey());
					Date nurseConfirmDate = DateUtil.toDate(saveLayoutInfo.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD);
					Double sortFkocskey = CommonUtils.parseDouble(saveLayoutInfo.getSortFkocskey());
					Double groupSer = CommonUtils.parseDouble(saveLayoutInfo.getGroupSer());
					pkocs1003 = CommonUtils.parseDouble(saveLayoutInfo.getPkocskey());
					String jusa = saveLayoutInfo.getJusa();
					if(StringUtils.isEmpty(jusa)){
						jusa = null;
					}
					String ordDanui = saveLayoutInfo.getOrdDanui();
					if(StringUtils.isEmpty(ordDanui)){
						ordDanui = null;
					}
					
					if("N".equalsIgnoreCase(saveLayoutInfo.getActionDoYn())){
						ocs1003cRepository.updateOcsoOCS1003P01UpdateDataOCS1003C(new Date(), request.getUserId(), saveLayoutInfo.getOrderGubun(),suryang, ordDanui,
								saveLayoutInfo.getDvTime(), dv, nalsu, jusa, saveLayoutInfo.getBogyongCode(), saveLayoutInfo.getEmergency(), saveLayoutInfo.getJaeryoJundalYn(),
								saveLayoutInfo.getJundalTable(), saveLayoutInfo.getJundalPart(), saveLayoutInfo.getMovePart(), saveLayoutInfo.getMuhyo(), saveLayoutInfo.getPortableYn(),
								"N", saveLayoutInfo.getDcYn(), saveLayoutInfo.getDcGubun(), saveLayoutInfo.getBannabYn(), saveLayoutInfo.getBannabConfirm(),
								"N", saveLayoutInfo.getPowderYn(), hopeDate, saveLayoutInfo.getHopeTime(), dv1, dv2, dv3, dv4, dv5, dv6, dv7, dv8, 
								saveLayoutInfo.getMixGroup(), saveLayoutInfo.getOrderRemark(), saveLayoutInfo.getNurseRemark(), saveLayoutInfo.getBomOccurYn(), bomSourceKey, 
								saveLayoutInfo.getNurseConfirmUser(), nurseConfirmDate, saveLayoutInfo.getNurseConfirmTime(), saveLayoutInfo.getDangilGumsaOrderYn(),
								saveLayoutInfo.getDangilGumsaResultYn(), saveLayoutInfo.getHomeCareYn(), saveLayoutInfo.getRegularYn(), saveLayoutInfo.getHubalChangeYn(),
								saveLayoutInfo.getPharmacy(), saveLayoutInfo.getJusaSpdGubun(), saveLayoutInfo.getDrgPackYn(), sortFkocskey, saveLayoutInfo.getWonyoiOrderYn(),
								saveLayoutInfo.getImsiDrugYn(), saveLayoutInfo.getSpecimenCode(), saveLayoutInfo.getGeneralDispYn(), saveLayoutInfo.getBogyongCodeSub(),
								groupSer, pkocs1003, hospCode);
					} else {
						String bogyongCode = saveLayoutInfo.getBogyongCode();
						if(StringUtils.isEmpty(bogyongCode)){
							bogyongCode = null;
						}
						
						int rowUpdate = ocs1003Repository.updateOcsoOCS1003P01UpdateDataOCS1003(new Date(), request.getUserId(), saveLayoutInfo.getOrderGubun(),suryang, ordDanui,
								saveLayoutInfo.getDvTime(), dv, nalsu, jusa, bogyongCode, saveLayoutInfo.getEmergency(), saveLayoutInfo.getJaeryoJundalYn(),
								saveLayoutInfo.getJundalTable(), saveLayoutInfo.getJundalPart(), saveLayoutInfo.getMovePart(), saveLayoutInfo.getMuhyo(), saveLayoutInfo.getPortableYn(),
								"N", saveLayoutInfo.getDcYn(), saveLayoutInfo.getDcGubun(), saveLayoutInfo.getBannabYn(), saveLayoutInfo.getBannabConfirm(),
								"N", saveLayoutInfo.getPowderYn(), hopeDate, saveLayoutInfo.getHopeTime(), dv1, dv2, dv3, dv4, dv5, dv6, dv7, dv8, 
								saveLayoutInfo.getMixGroup(), saveLayoutInfo.getOrderRemark(), saveLayoutInfo.getNurseRemark(), saveLayoutInfo.getBomOccurYn(), bomSourceKey, 
								saveLayoutInfo.getNurseConfirmUser(), nurseConfirmDate, saveLayoutInfo.getNurseConfirmTime(), saveLayoutInfo.getDangilGumsaOrderYn(),
								saveLayoutInfo.getDangilGumsaResultYn(), saveLayoutInfo.getHomeCareYn(), saveLayoutInfo.getRegularYn(), saveLayoutInfo.getHubalChangeYn(),
								saveLayoutInfo.getPharmacy(), saveLayoutInfo.getJusaSpdGubun(), saveLayoutInfo.getDrgPackYn(), sortFkocskey, saveLayoutInfo.getWonyoiOrderYn(),
								saveLayoutInfo.getImsiDrugYn(), saveLayoutInfo.getSpecimenCode(), saveLayoutInfo.getGeneralDispYn(), saveLayoutInfo.getBogyongCodeSub(),
								groupSer, pkocs1003, hospCode);
						
						if(invUsage && rowUpdate > 0){
							Double reserveQty = 0.0;
							//reserveQty = suryang*dv*nalsu; //TODO wait for BA confirm
							reserveQty = commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(saveLayoutInfo.getNalsu()), CommonUtils.parseDouble(saveLayoutInfo.getSuryang()), CommonUtils.parseDouble(saveLayoutInfo.getDv()), saveLayoutInfo.getDvTime());
							inv0001Repository.updateQTy(reserveQty, hospCode, pkocs1003);
						}
						// fix bug 11480 
							inv1001Repository.updateInv1001ByFkocs1003(hospCode, userId, saveLayoutInfo.getHangmogCode(), saveLayoutInfo.getIoGubun(), saveLayoutInfo.getJundalPart(), 
								saveLayoutInfo.getJundalPart(), suryang, saveLayoutInfo.getDvTime(), dv, ordDanui, nalsu, saveLayoutInfo.getJundalPart(), pkocs1003);
					} 
					
				}
				// [END] INSERT/UPDATE OCS1003/OCS1003C
				
				// call PR_OCS_MAKE_REGULAR_ORDER
				if(!DataRowState.UNCHANGED.getValue().equalsIgnoreCase(saveLayoutInfo.getRowState())){
					String resultCallPr = ocs1023Repository.callPrOcsMakeRegularOrder(hospCode, "1", pkocs1003, request.getUserId());
					if(!"0".equals(resultCallPr)){
						response.setResult(false);
						return response;
					}
				}
			}
			
			// inventory logic save
			if (invUsage && !CollectionUtils.isEmpty(listOcs1003Inserted)){
				insertInvs(hospCode, userId, listOcs1003Inserted, localTimeZone, language);
			}
		}
		
		Double naewonKey = CommonUtils.parseDouble(request.getNaewonKey());
        Date naewonDate = DateUtil.toDate(request.getNaewonDate(), DateUtil.PATTERN_YYMMDD);
        ocs1003Repository.callOcsoOCS1003P01OutOrderEndTemp(hospCode, naewonKey, naewonDate);
        
        // event sync prescription
    	if(!StringUtils.isEmpty(patientCode)){
    		LOG.info("Sync prescription throw PATIENT_EVENT!!! hospCode=" + hospCode + ", patientCode=" + patientCode);
    		NuroServiceProto.PatientEvent.Builder builder = NuroServiceProto.PatientEvent.newBuilder()
					.setHospCode(hospCode).setPatientCode(patientCode);
    		List<SyncDrugInfo> drugList = out1001Repository.getDrugInfo(hospCode, patientCode, language);
    		if(!CollectionUtils.isEmpty(drugList)){
    			for (SyncDrugInfo info : drugList) {
        			NuroModelProto.SyncDrug.Builder item = NuroModelProto.SyncDrug.newBuilder();
        			BeanUtils.copyProperties(info, item, language);
        			item.setMedicineId(info.getMedicineId().longValue());
        			item.setPrescriptionName(CommonUtils.parseString(info.getPrescriptionName()));
        			item.setDose(CommonUtils.parseString(info.getDose()));
        			item.setFrequency(info.getFrequency().toString());
        			item.setDays(info.getDays().toString());
        			item.setUpdated(info.getUpdated() == null ? "": DateUtil.toString(info.getUpdated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
        			item.setCreated(info.getCreated() == null ? "": DateUtil.toString(info.getCreated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
        			item.setPrescriptionId(info.getPrescriptionId() == null ? 0 : info.getPrescriptionId().longValue());
        			item.setPresciptionUpdated(info.getPresciptionUpdated() == null ? "": DateUtil.toString(info.getPresciptionUpdated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
        			item.setPresciptionCreated(info.getPresciptionCreated() == null ? "": DateUtil.toString(info.getPresciptionCreated(), DateUtil.PATTERN_YYYMMDD_HHMMSS_FULL));
        			builder.addDrugInfo(item);
    			}
    		} else {
    			builder.setDeletedAllDrug(true);
    		}
    		
			LOG.info("Sync drug Publish!!!");
			publish(vertx, builder.build());
    	}
		response.setResult(true);
		return response;
	}
	
	private Ocs1003C insertOcs1003C(OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo saveLayoutInfo, String hospCode, String userId, int localTimeZone){
		String pkocskey = saveLayoutInfo.getPkocskey();
		if(StringUtils.isEmpty(pkocskey)){
			pkocskey = commonRepository.getNextVal("OCSKEY_SEQ");
		}
		
		BigDecimal fkout1001 = new BigDecimal(saveLayoutInfo.getInOutKey());
		String seqStr = ocs1003Repository.getOcsoOCS1003P01GetMaxOcs1003Seq(fkout1001, hospCode);
		LOG.info("OCS1003P01SaveLayOutHandler seqStr =" + seqStr);
		
		if (StringUtils.isEmpty(seqStr)){
			seqStr = "1";
		}
		
		Ocs1003C ocs1003c = new Ocs1003C();
		ocs1003c.setSunabSuryang(0D);
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		
		ocs1003c.setSysDate(sysDate);
		ocs1003c.setSysId(userId);
		ocs1003c.setUpdDate(sysDate);
		ocs1003c.setUpdId(userId);
		ocs1003c.setHospCode(hospCode);
		double pkocs1003 = CommonUtils.parseDouble(pkocskey);
		ocs1003c.setPkocs1003c(pkocs1003);
		
		ocs1003c.setBunho(saveLayoutInfo.getBunho());
		Date orderDate = DateUtil.toDate(saveLayoutInfo.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setOrderDate(orderDate);
		ocs1003c.setGwa(saveLayoutInfo.getGwa());
		ocs1003c.setDoctor(saveLayoutInfo.getDoctor());
		ocs1003c.setNaewonType(saveLayoutInfo.getNaewonType());
		ocs1003c.setInputId(saveLayoutInfo.getInputId());
		ocs1003c.setInputPart(saveLayoutInfo.getInputPart());
		ocs1003c.setInputGubun(saveLayoutInfo.getInputGubun());
		Double seq = CommonUtils.parseDouble(seqStr);
		ocs1003c.setSeq(seq);
		
		ocs1003c.setHangmogCode(saveLayoutInfo.getHangmogCode());
		Double groupSer = CommonUtils.parseDouble(saveLayoutInfo.getGroupSer());
		ocs1003c.setGroupSer(groupSer);
		ocs1003c.setSlipCode(saveLayoutInfo.getSlipCode());
		ocs1003c.setNdayYn(StringUtils.isEmpty(saveLayoutInfo.getNdayYn()) ? null : saveLayoutInfo.getNdayYn());
		ocs1003c.setOrderGubun(saveLayoutInfo.getOrderGubun());
		if(!StringUtils.isEmpty(saveLayoutInfo.getSpecimenCode())){
			ocs1003c.setSpecimenCode(saveLayoutInfo.getSpecimenCode());
		}else{
			ocs1003c.setSpecimenCode("*");
		}
		Double suryang = CommonUtils.parseDouble(saveLayoutInfo.getSuryang());
		ocs1003c.setSuryang(suryang);
		if(!StringUtils.isEmpty(saveLayoutInfo.getOrdDanui())){
			ocs1003c.setOrdDanui(saveLayoutInfo.getOrdDanui());
		}
		ocs1003c.setDvTime(saveLayoutInfo.getDvTime());
		Double dv = CommonUtils.parseDouble(saveLayoutInfo.getDv());
		ocs1003c.setDv(dv);
		Double nalsu = CommonUtils.parseDouble(saveLayoutInfo.getNalsu());
		ocs1003c.setNalsu(nalsu);
		if(!StringUtils.isEmpty(saveLayoutInfo.getJusa())){
			ocs1003c.setJusa(saveLayoutInfo.getJusa());
		}
		if(!StringUtils.isEmpty(saveLayoutInfo.getBogyongCode())){
			ocs1003c.setBogyongCode(saveLayoutInfo.getBogyongCode());
		}
		ocs1003c.setEmergency(saveLayoutInfo.getEmergency());
		ocs1003c.setJaeryoJundalYn(StringUtils.isEmpty(saveLayoutInfo.getJaeryoJundalYn()) ? null : saveLayoutInfo.getJaeryoJundalYn());
		ocs1003c.setJundalTable(saveLayoutInfo.getJundalTable());
		if(!StringUtils.isEmpty(saveLayoutInfo.getJundalPart())){
			ocs1003c.setJundalPart(saveLayoutInfo.getJundalPart());
		}
		ocs1003c.setMovePart(saveLayoutInfo.getMovePart());
		if(!StringUtils.isEmpty(saveLayoutInfo.getMuhyo())){
			ocs1003c.setMuhyo(saveLayoutInfo.getMuhyo());
		}
		ocs1003c.setPortableYn(StringUtils.isEmpty(saveLayoutInfo.getPortableYn()) ? null : saveLayoutInfo.getPortableYn());
		ocs1003c.setAntiCancerYn("N");
		ocs1003c.setPay(saveLayoutInfo.getPay());
		Date reserDate = DateUtil.toDate(saveLayoutInfo.getReserDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setReserDate(reserDate);
		if(!StringUtils.isEmpty(saveLayoutInfo.getReserTime())){
			ocs1003c.setReserTime(saveLayoutInfo.getReserTime());
		}
		if(!StringUtils.isEmpty(saveLayoutInfo.getDcYn())){
			ocs1003c.setDcYn(saveLayoutInfo.getDcYn());
		}
		ocs1003c.setDcGubun(saveLayoutInfo.getDcGubun());
		ocs1003c.setBannabYn(StringUtils.isEmpty(saveLayoutInfo.getBannabYn()) ? null : saveLayoutInfo.getBannabYn());
		ocs1003c.setBannabConfirm(saveLayoutInfo.getBannabConfirm());
		ocs1003c.setActDoctor(saveLayoutInfo.getActDoctor());
		ocs1003c.setActGwa(saveLayoutInfo.getActGwa());
		ocs1003c.setActBuseo(saveLayoutInfo.getActBuseo());
		ocs1003c.setOcsFlag(saveLayoutInfo.getOcsFlag());
		ocs1003c.setSgCode(saveLayoutInfo.getSgCode());
		Date sgYmd = DateUtil.toDate(saveLayoutInfo.getSgYmd(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setSgYmd(sgYmd);
		ocs1003c.setIoGubun(saveLayoutInfo.getIoGubun());
		ocs1003c.setAfterActYn(StringUtils.isEmpty(saveLayoutInfo.getAfterActYn()) ? null : saveLayoutInfo.getAfterActYn());
		ocs1003c.setBichiYn(StringUtils.isEmpty(saveLayoutInfo.getBichiYn()) ? null : saveLayoutInfo.getBichiYn());
		Double drgBunho = CommonUtils.parseDouble(saveLayoutInfo.getDrgBunho());
		ocs1003c.setDrgBunho(drgBunho);
		if(!StringUtils.isEmpty(saveLayoutInfo.getSubSusul())){
			ocs1003c.setSubSusul(saveLayoutInfo.getSubSusul());
		}
		ocs1003c.setWonyoiOrderYn(saveLayoutInfo.getWonyoiOrderYn());
		ocs1003c.setSutakYn("N");
		ocs1003c.setPowderYn(StringUtils.isEmpty(saveLayoutInfo.getPowderYn()) ? null : saveLayoutInfo.getPowderYn());
		Date hopeDate = DateUtil.toDate(saveLayoutInfo.getHopeDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setHopeDate(hopeDate);
		ocs1003c.setHopeTime(saveLayoutInfo.getHopeTime());
		Double dv1 = CommonUtils.parseDouble(saveLayoutInfo.getDv1());
		ocs1003c.setDv1(dv1);
		Double dv2 = CommonUtils.parseDouble(saveLayoutInfo.getDv2());
		ocs1003c.setDv2(dv2);
		Double dv3 = CommonUtils.parseDouble(saveLayoutInfo.getDv3());
		ocs1003c.setDv3(dv3);
		Double dv4 = CommonUtils.parseDouble(saveLayoutInfo.getDv4());
		ocs1003c.setDv4(dv4);
		ocs1003c.setMixGroup(saveLayoutInfo.getMixGroup());
		ocs1003c.setOrderRemark(saveLayoutInfo.getOrderRemark());
		ocs1003c.setNurseRemark(saveLayoutInfo.getNurseRemark());
		ocs1003c.setBomOccurYn(StringUtils.isEmpty(saveLayoutInfo.getBomOccurYn()) ? null : saveLayoutInfo.getBomOccurYn());
		Double bomSourceKey = CommonUtils.parseDouble(saveLayoutInfo.getBomSourceKey());
		ocs1003c.setBomSourceKey(bomSourceKey);
		ocs1003c.setDisplayYn(StringUtils.isEmpty(saveLayoutInfo.getDisplayYn()) ? null : saveLayoutInfo.getDisplayYn());
		ocs1003c.setNurseConfirmUser(saveLayoutInfo.getNurseConfirmUser());
		Date nurseConfirmDate = DateUtil.toDate(saveLayoutInfo.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setNurseConfirmDate(nurseConfirmDate);
		ocs1003c.setNurseConfirmTime(saveLayoutInfo.getNurseConfirmTime());
		ocs1003c.setTelYn(StringUtils.isEmpty(saveLayoutInfo.getTelYn()) ? null : saveLayoutInfo.getTelYn());
		ocs1003c.setDangilGumsaOrderYn(StringUtils.isEmpty(saveLayoutInfo.getDangilGumsaOrderYn()) ? null : saveLayoutInfo.getDangilGumsaOrderYn());
		ocs1003c.setDangilGumsaResultYn(StringUtils.isEmpty(saveLayoutInfo.getDangilGumsaResultYn()) ? null : saveLayoutInfo.getDangilGumsaResultYn());
		ocs1003c.setHomeCareYn(StringUtils.isEmpty(saveLayoutInfo.getHomeCareYn()) ? null : saveLayoutInfo.getHomeCareYn());
		ocs1003c.setRegularYn(StringUtils.isEmpty(saveLayoutInfo.getRegularYn()) ? null : saveLayoutInfo.getRegularYn());
		ocs1003c.setInputTab(saveLayoutInfo.getInputTab());
		ocs1003c.setHubalChangeYn(StringUtils.isEmpty(saveLayoutInfo.getHubalChangeYn()) ? null : saveLayoutInfo.getHubalChangeYn());
		ocs1003c.setPharmacy(saveLayoutInfo.getPharmacy());
		ocs1003c.setJusaSpdGubun(saveLayoutInfo.getJusaSpdGubun());
		ocs1003c.setDrgPackYn(StringUtils.isEmpty(saveLayoutInfo.getDrgPackYn()) ? null : saveLayoutInfo.getDrgPackYn());
		Double sortFkocskey = CommonUtils.parseDouble(saveLayoutInfo.getSortFkocskey());
		ocs1003c.setSortFkocskey(sortFkocskey);
		ocs1003c.setFkout1001(fkout1001);
		ocs1003c.setImsiDrugYn(StringUtils.isEmpty(saveLayoutInfo.getImsiDrugYn()) ? null : saveLayoutInfo.getImsiDrugYn());
		ocs1003c.setGeneralDispYn(StringUtils.isEmpty(saveLayoutInfo.getGeneralDispYn()) ? null : saveLayoutInfo.getGeneralDispYn());
		Double dv5 = CommonUtils.parseDouble(saveLayoutInfo.getDv5());
		ocs1003c.setDv5(dv5);
		Double dv6 = CommonUtils.parseDouble(saveLayoutInfo.getDv6());
		ocs1003c.setDv6(dv6);
		Double dv7 = CommonUtils.parseDouble(saveLayoutInfo.getDv7());
		ocs1003c.setDv7(dv7);
		Double dv8 = CommonUtils.parseDouble(saveLayoutInfo.getDv8());
		ocs1003c.setDv8(dv8);
		ocs1003c.setBogyongCodeSub(saveLayoutInfo.getBogyongCodeSub());
		if(!StringUtils.isEmpty(saveLayoutInfo.getInsteadYn())){
			ocs1003c.setInsteadYn(saveLayoutInfo.getInsteadYn());
		}
		ocs1003c.setInsteadId(saveLayoutInfo.getInsteadId());
		Date insteadDate =  DateUtil.toDate(saveLayoutInfo.getInsteadDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003c.setInsteadDate(insteadDate);
		ocs1003c.setInsteadTime(saveLayoutInfo.getInsteadTime());
		if(!StringUtils.isEmpty(saveLayoutInfo.getApproveYn())){
			ocs1003c.setApproveYn(saveLayoutInfo.getApproveYn());
		}
		ocs1003c.setPostapproveYn(StringUtils.isEmpty(saveLayoutInfo.getPostapproveYn()) ? null : saveLayoutInfo.getPostapproveYn());
//		if(("N".equals(saveLayoutInfo.getWonnaeDrgYn()) || (Department.HOM.getValue().equalsIgnoreCase(saveLayoutInfo.getJundalPart()))) 
//				&& !"CK".equals(saveLayoutInfo.getInputGubun())){
//			Date actingDate = DateUtil.toDate(new SimpleDateFormat(DateUtil.PATTERN_YYMMDD).format(sysDate), DateUtil.PATTERN_YYMMDD);
//			ocs1003c.setActingDate(actingDate);
//		}
		LOG.info(" OCS1003P01SaveLayOutHandler OBJECT ocs1003 :" + ocs1003c.toString());

		ocs1003cRepository.save(ocs1003c);
		return ocs1003c;
	}
	
	private Ocs1003 insertOcs1003(OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo saveLayoutInfo, String hospCode, String userId, int localTimeZone){
		String pkocskey = saveLayoutInfo.getPkocskey();
		if(StringUtils.isEmpty(pkocskey)){
			pkocskey = commonRepository.getNextVal("OCSKEY_SEQ");
		}
		
		BigDecimal fkout1001 = new BigDecimal(saveLayoutInfo.getInOutKey());
		String seqStr = ocs1003Repository.getOcsoOCS1003P01GetMaxOcs1003Seq(fkout1001, hospCode);
		LOG.info("OCS1003P01SaveLayOutHandler seqStr =" + seqStr);
		
		if (StringUtils.isEmpty(seqStr)){
			seqStr = "1";
		}
		
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		
		Ocs1003 ocs1003 = new Ocs1003();
		ocs1003.setSunabSuryang(0D);
		ocs1003.setSysDate(sysDate);
		ocs1003.setSysId(userId);
		ocs1003.setUpdDate(sysDate);
		ocs1003.setUpdId(userId);
		ocs1003.setHospCode(hospCode);
		double pkocs1003 = CommonUtils.parseDouble(pkocskey);
		ocs1003.setPkocs1003(pkocs1003);
		
		ocs1003.setBunho(saveLayoutInfo.getBunho());
		Date orderDate = DateUtil.toDate(saveLayoutInfo.getOrderDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setOrderDate(orderDate);
		ocs1003.setGwa(saveLayoutInfo.getGwa());
		ocs1003.setDoctor(saveLayoutInfo.getDoctor());
		ocs1003.setNaewonType(saveLayoutInfo.getNaewonType());
		ocs1003.setInputId(saveLayoutInfo.getInputId());
		ocs1003.setInputPart(saveLayoutInfo.getInputPart());
		ocs1003.setInputGubun(saveLayoutInfo.getInputGubun());
		Double seq = CommonUtils.parseDouble(seqStr);
		ocs1003.setSeq(seq);
		
		ocs1003.setHangmogCode(saveLayoutInfo.getHangmogCode());
		Double groupSer = CommonUtils.parseDouble(saveLayoutInfo.getGroupSer());
		ocs1003.setGroupSer(groupSer);
		ocs1003.setSlipCode(saveLayoutInfo.getSlipCode());
		ocs1003.setNdayYn(StringUtils.isEmpty(saveLayoutInfo.getNdayYn()) ? null : saveLayoutInfo.getNdayYn());
		ocs1003.setOrderGubun(saveLayoutInfo.getOrderGubun());
		if(!StringUtils.isEmpty(saveLayoutInfo.getSpecimenCode())){
			ocs1003.setSpecimenCode(saveLayoutInfo.getSpecimenCode());
		}else{
			ocs1003.setSpecimenCode("*");
		}
		Double suryang = CommonUtils.parseDouble(saveLayoutInfo.getSuryang());
		ocs1003.setSuryang(suryang);
		if(!StringUtils.isEmpty(saveLayoutInfo.getOrdDanui())){
			ocs1003.setOrdDanui(saveLayoutInfo.getOrdDanui());
		}
		ocs1003.setDvTime(saveLayoutInfo.getDvTime());
		Double dv = CommonUtils.parseDouble(saveLayoutInfo.getDv());
		ocs1003.setDv(dv);
		Double nalsu = CommonUtils.parseDouble(saveLayoutInfo.getNalsu());
		ocs1003.setNalsu(nalsu);
		if(!StringUtils.isEmpty(saveLayoutInfo.getJusa())){
			ocs1003.setJusa(saveLayoutInfo.getJusa());
		}
		if(!StringUtils.isEmpty(saveLayoutInfo.getBogyongCode())){
			ocs1003.setBogyongCode(saveLayoutInfo.getBogyongCode());
		}
		ocs1003.setEmergency(saveLayoutInfo.getEmergency());
		ocs1003.setJaeryoJundalYn(StringUtils.isEmpty(saveLayoutInfo.getJaeryoJundalYn()) ? null : saveLayoutInfo.getJaeryoJundalYn());
		ocs1003.setJundalTable(saveLayoutInfo.getJundalTable());
		if(!StringUtils.isEmpty(saveLayoutInfo.getJundalPart())){
			ocs1003.setJundalPart(saveLayoutInfo.getJundalPart());
		}
		ocs1003.setMovePart(saveLayoutInfo.getMovePart());
		if(!StringUtils.isEmpty(saveLayoutInfo.getMuhyo())){
			ocs1003.setMuhyo(saveLayoutInfo.getMuhyo());
		}
		ocs1003.setPortableYn(StringUtils.isEmpty(saveLayoutInfo.getPortableYn()) ? null : saveLayoutInfo.getPortableYn());
		ocs1003.setAntiCancerYn("N");
		ocs1003.setPay(saveLayoutInfo.getPay());
		Date reserDate = DateUtil.toDate(saveLayoutInfo.getReserDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setReserDate(reserDate);
		if(!StringUtils.isEmpty(saveLayoutInfo.getReserTime())){
			ocs1003.setReserTime(saveLayoutInfo.getReserTime());
		}
		if(!StringUtils.isEmpty(saveLayoutInfo.getDcYn())){
			ocs1003.setDcYn(saveLayoutInfo.getDcYn());
		}
		ocs1003.setDcGubun(saveLayoutInfo.getDcGubun());
		ocs1003.setBannabYn(StringUtils.isEmpty(saveLayoutInfo.getBannabYn()) ? null : saveLayoutInfo.getBannabYn());
		ocs1003.setBannabConfirm(saveLayoutInfo.getBannabConfirm());
		//ocs1003.setActDoctor(saveLayoutInfo.getActDoctor());
		ocs1003.setActDoctor(userId);
		ocs1003.setActGwa(saveLayoutInfo.getActGwa());
		//ocs1003.setActBuseo(saveLayoutInfo.getActBuseo());
		ocs1003.setActBuseo(saveLayoutInfo.getGwa());
		ocs1003.setOcsFlag(saveLayoutInfo.getOcsFlag());
		ocs1003.setSgCode(saveLayoutInfo.getSgCode());
		Date sgYmd = DateUtil.toDate(saveLayoutInfo.getSgYmd(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setSgYmd(sgYmd);
		ocs1003.setIoGubun(saveLayoutInfo.getIoGubun());
		ocs1003.setAfterActYn(StringUtils.isEmpty(saveLayoutInfo.getAfterActYn()) ? null : saveLayoutInfo.getAfterActYn());
		ocs1003.setBichiYn(StringUtils.isEmpty(saveLayoutInfo.getBichiYn()) ? null : saveLayoutInfo.getBichiYn());
		Double drgBunho = CommonUtils.parseDouble(saveLayoutInfo.getDrgBunho());
		ocs1003.setDrgBunho(drgBunho);
		if(!StringUtils.isEmpty(saveLayoutInfo.getSubSusul())){
			ocs1003.setSubSusul(saveLayoutInfo.getSubSusul());
		}
		ocs1003.setWonyoiOrderYn(StringUtils.isEmpty(saveLayoutInfo.getWonyoiOrderYn()) ? null : saveLayoutInfo.getWonyoiOrderYn());
		ocs1003.setSutakYn("N");
		ocs1003.setPowderYn(StringUtils.isEmpty(saveLayoutInfo.getPowderYn()) ? null : saveLayoutInfo.getPowderYn());
		Date hopeDate = DateUtil.toDate(saveLayoutInfo.getHopeDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setHopeDate(hopeDate);
		ocs1003.setHopeTime(saveLayoutInfo.getHopeTime());
		Double dv1 = CommonUtils.parseDouble(saveLayoutInfo.getDv1());
		ocs1003.setDv1(dv1);
		Double dv2 = CommonUtils.parseDouble(saveLayoutInfo.getDv2());
		ocs1003.setDv2(dv2);
		Double dv3 = CommonUtils.parseDouble(saveLayoutInfo.getDv3());
		ocs1003.setDv3(dv3);
		Double dv4 = CommonUtils.parseDouble(saveLayoutInfo.getDv4());
		ocs1003.setDv4(dv4);
		ocs1003.setMixGroup(saveLayoutInfo.getMixGroup());
		ocs1003.setOrderRemark(saveLayoutInfo.getOrderRemark());
		ocs1003.setNurseRemark(saveLayoutInfo.getNurseRemark());
		ocs1003.setBomOccurYn(StringUtils.isEmpty(saveLayoutInfo.getBomOccurYn()) ? null : saveLayoutInfo.getBomOccurYn());
		Double bomSourceKey = CommonUtils.parseDouble(saveLayoutInfo.getBomSourceKey());
		ocs1003.setBomSourceKey(bomSourceKey);
		ocs1003.setDisplayYn(StringUtils.isEmpty(saveLayoutInfo.getDisplayYn()) ? null : saveLayoutInfo.getDisplayYn());
		ocs1003.setNurseConfirmUser(saveLayoutInfo.getNurseConfirmUser());
		Date nurseConfirmDate = DateUtil.toDate(saveLayoutInfo.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setNurseConfirmDate(nurseConfirmDate);
		ocs1003.setNurseConfirmTime(saveLayoutInfo.getNurseConfirmTime());
		ocs1003.setTelYn(StringUtils.isEmpty(saveLayoutInfo.getTelYn()) ? null : saveLayoutInfo.getTelYn());
		ocs1003.setDangilGumsaOrderYn(StringUtils.isEmpty(saveLayoutInfo.getDangilGumsaOrderYn()) ? null : saveLayoutInfo.getDangilGumsaOrderYn());
		ocs1003.setDangilGumsaResultYn(StringUtils.isEmpty(saveLayoutInfo.getDangilGumsaResultYn()) ? null : saveLayoutInfo.getDangilGumsaResultYn());
		ocs1003.setHomeCareYn(StringUtils.isEmpty(saveLayoutInfo.getHomeCareYn()) ? null : saveLayoutInfo.getHomeCareYn());
		ocs1003.setRegularYn(StringUtils.isEmpty(saveLayoutInfo.getRegularYn()) ? null : saveLayoutInfo.getRegularYn());
		ocs1003.setInputTab(saveLayoutInfo.getInputTab());
		ocs1003.setHubalChangeYn(StringUtils.isEmpty(saveLayoutInfo.getHubalChangeYn()) ? null : saveLayoutInfo.getHubalChangeYn());
		ocs1003.setPharmacy(saveLayoutInfo.getPharmacy());
		ocs1003.setJusaSpdGubun(saveLayoutInfo.getJusaSpdGubun());
		ocs1003.setDrgPackYn(StringUtils.isEmpty(saveLayoutInfo.getDrgPackYn()) ? null : saveLayoutInfo.getDrgPackYn());
		Double sortFkocskey = CommonUtils.parseDouble(saveLayoutInfo.getSortFkocskey());
		ocs1003.setSortFkocskey(sortFkocskey);
		ocs1003.setFkout1001(fkout1001);
		ocs1003.setImsiDrugYn(StringUtils.isEmpty(saveLayoutInfo.getImsiDrugYn()) ? null : saveLayoutInfo.getImsiDrugYn());
		ocs1003.setGeneralDispYn(StringUtils.isEmpty(saveLayoutInfo.getGeneralDispYn()) ? null : saveLayoutInfo.getGeneralDispYn());
		Double dv5 = CommonUtils.parseDouble(saveLayoutInfo.getDv5());
		ocs1003.setDv5(dv5);
		Double dv6 = CommonUtils.parseDouble(saveLayoutInfo.getDv6());
		ocs1003.setDv6(dv6);
		Double dv7 = CommonUtils.parseDouble(saveLayoutInfo.getDv7());
		ocs1003.setDv7(dv7);
		Double dv8 = CommonUtils.parseDouble(saveLayoutInfo.getDv8());
		ocs1003.setDv8(dv8);
		ocs1003.setBogyongCodeSub(saveLayoutInfo.getBogyongCodeSub());
		if(!StringUtils.isEmpty(saveLayoutInfo.getInsteadYn())){
			ocs1003.setInsteadYn(saveLayoutInfo.getInsteadYn());
		}
		ocs1003.setInsteadId(saveLayoutInfo.getInsteadId());
		Date insteadDate =  DateUtil.toDate(saveLayoutInfo.getInsteadDate(), DateUtil.PATTERN_YYMMDD);
		ocs1003.setInsteadDate(insteadDate);
		ocs1003.setInsteadTime(saveLayoutInfo.getInsteadTime());
		if(!StringUtils.isEmpty(saveLayoutInfo.getApproveYn())){
			ocs1003.setApproveYn(saveLayoutInfo.getApproveYn());
		}
		ocs1003.setPostapproveYn(StringUtils.isEmpty(saveLayoutInfo.getPostapproveYn()) ? null : saveLayoutInfo.getPostapproveYn());
		
		ocs1003.setPaidYn("N");
		
//		if(("N".equals(saveLayoutInfo.getWonnaeDrgYn()) || (Department.HOM.getValue().equalsIgnoreCase(saveLayoutInfo.getJundalPart()))) 
//				&& !"CK".equals(saveLayoutInfo.getInputGubun())){
//			Date actingDate = DateUtil.toDate(new SimpleDateFormat(DateUtil.PATTERN_YYMMDD).format(sysDate), DateUtil.PATTERN_YYMMDD);
//			ocs1003.setActingDate(actingDate);
//		}
		
		LOG.info(" OCS1003P01SaveLayOutHandler OBJECT ocs1003 :" + ocs1003.toString());
		ocs1003Repository.save(ocs1003);
		return ocs1003;
	}
	
	private void insertInvs(String hospCode, String userId, List<Ocs1003> ocsList, int localTimeZone, String language){
		
		for (Ocs1003 ocs1003 : ocsList) {
			String jaeryoCode = inv0110Repository.findJaeryoCode(hospCode, ocs1003.getHangmogCode());
			if(!StringUtils.isEmpty(jaeryoCode)){
				Integer count = inv0001Repository.countByHospCodeAndFkOcs1003(hospCode, ocs1003.getPkocs1003());
				if(count == 0){
					insertInv0001(ocs1003, userId);
				}
			}
		}
	}
	
	private Inv0001 insertInv0001(Ocs1003 ocs1003, String userId){
		Inv0001 inv0001 = new Inv0001();
		inv0001.setFkocs1003(ocs1003.getPkocs1003());
		inv0001.setReserveCode(ocs1003.getHangmogCode());
		//inv0001.setReserveQty(ocs1003.getSuryang()*ocs1003.getDv()*ocs1003.getNalsu()); //TODO wait for BA confirm
		inv0001.setReserveQty(commonRepository.callFnDrgWonyoiTotSurang(ocs1003.getNalsu(), ocs1003.getSuryang(), ocs1003.getDv(), ocs1003.getDvTime()));
		inv0001.setHospCode(ocs1003.getHospCode());
		inv0001.setActiveFlg(new BigDecimal(1));
		inv0001.setSysId(userId);
		inv0001.setUpdId(userId);
		inv0001.setCreated(new Date());
		inv0001.setUpdated(new Date());
		
		inv0001Repository.save(inv0001);
		return inv0001;
	}
	
	private void insertINV1001(OcsoModelProto.OCS1003P01LaySaveLayoutListItemInfo  info, String userId, Double pkinv1001, 
			  Double pkocsInv, String hospCode){
		Inv1001 inv1001 = new Inv1001();
		inv1001.setSysDate(new Date());
		inv1001.setSysId(userId);
		inv1001.setUpdDate(new Date());
		inv1001.setPkinv1001(pkinv1001);
		inv1001.setBunho(info.getBunho());
		inv1001.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD));
		inv1001.setInOutGubun(info.getIoGubun());
		inv1001.setInputPart(info.getJundalPart());
		inv1001.setHangmogCode(info.getHangmogCode());
		inv1001.setJaeryoCode(info.getHangmogCode());
		inv1001.setSubulBuseo(info.getJundalPart());
		inv1001.setSuryang(CommonUtils.parseDouble(info.getSuryang()));
		inv1001.setDvTime(info.getDvTime());
		inv1001.setDv(CommonUtils.parseDouble(info.getDv()));
		inv1001.setNalsu(StringUtils.isEmpty(info.getNalsu()) ? new Double(1) : CommonUtils.parseDouble(info.getNalsu()));
		inv1001.setOrdDanui(info.getOrdDanui());
		inv1001.setActingDate(new Date());
		inv1001.setActBuseo(info.getJundalPart());
		if("I".equalsIgnoreCase(info.getIoGubun())){
			inv1001.setFkocs2003(pkocsInv);
		}else{
			inv1001.setFkocs1003(pkocsInv);
		}
		inv1001.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
		inv1001.setHospCode(hospCode);
		inv1001Repository.save(inv1001);
	}
	
}
