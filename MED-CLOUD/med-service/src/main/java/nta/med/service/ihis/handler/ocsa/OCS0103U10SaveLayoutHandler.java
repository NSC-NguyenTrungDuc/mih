package nta.med.service.ihis.handler.ocsa;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.ocs.Ocs2003;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.ocs.Ocs1053Repository;
import nta.med.data.dao.medi.ocs.Ocs2003Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto.PrOcsInterfaceInsertInfo;
import nta.med.service.ihis.proto.OcsaModelProto.OCS0103U10SaveLayoutInfo;
import nta.med.service.ihis.proto.OcsaServiceProto;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SaveLayoutRequest;
import nta.med.service.ihis.proto.OcsaServiceProto.OCS0103U10SaveLayoutResponse;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class OCS0103U10SaveLayoutHandler 
	extends ScreenHandler<OcsaServiceProto.OCS0103U10SaveLayoutRequest, OcsaServiceProto.OCS0103U10SaveLayoutResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(OCS0103U10SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Ocs2003Repository ocs2003Repository;   
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Resource
	private CommonRepository commonRepository; 
	@Resource                                                                                                       
	private Ocs1053Repository ocs1053Repository;   
	                                                                                                                
	@Override                                                                                                       
	public OCS0103U10SaveLayoutResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OCS0103U10SaveLayoutRequest request) throws Exception {                                                                   
  	   	OcsaServiceProto.OCS0103U10SaveLayoutResponse.Builder response = OcsaServiceProto.OCS0103U10SaveLayoutResponse.newBuilder();                      
      	String ioFlag="";
		Integer result=null;
		String hospCode = getHospitalCode(vertx, sessionId);
		//PR_OCS_INTERFACE_INSERT 
		String prOcsresult="";
		for(PrOcsInterfaceInsertInfo item : request.getInterfaceInsertItemList()){ 
			prOcsresult=ocs1053Repository.callPrOcsInterfaceInsert(hospCode,item.getIoGubun(),CommonUtils.parseInteger(item.getPkKey()),item.getUserId());
			if(!prOcsresult.equals("0")){
				throw new ExecutionException(response.build());
			}
		}
		//PR_OCS_APPLY_NDAY_ORDER
		if (!StringUtils.isEmpty(request.getOrderDate()) && DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD) == null) {
			throw new ExecutionException(response.build());
        	//rpcBuilder.setResult(Rpc.RpcMessage.Result.SERVICE_REJECTED);
        }else{
			 ioFlag= ocs2003Repository.callPrOcsApplyNdayOrderOCS0103U13(hospCode,request.getBunho(),DateUtil.toDate(request.getOrderDate(), DateUtil.PATTERN_YYMMDD));
			if(!StringUtils.isEmpty(ioFlag)){
				if(!ioFlag.equals("0")){
					throw new ExecutionException(response.build());
				}
				response.setResult(ioFlag);
			}
        }	
		for(OCS0103U10SaveLayoutInfo  info : request.getSaveLayoutItemList()){
			 if(DataRowState.ADDED.getValue().equalsIgnoreCase(info.getRowState())) {
				 Double pkocskey=null;
				 Double seq=null;
				if(StringUtils.isEmpty(info.getPkocskey())){
					//get f_pkocskey
					pkocskey = CommonUtils.parseDouble(commonRepository.getNextVal("OCSKEY_SEQ"));
				}
				if(StringUtils.isEmpty(info.getSeq())){
					//get f_seq
					seq=ocs2003Repository.getMaxSeqOCS0103U13SaveLayout(hospCode,info.getBunho(),CommonUtils.parseDouble(info.getPkocskey()),info.getOrderDate());
					if(seq ==null){
						seq =new Double(1);
					}
				}
				insertOcs2003(info, seq, pkocskey, hospCode);
				result =1;
			 }else if(DataRowState.MODIFIED.getValue().equalsIgnoreCase(info.getRowState())){
				 result = updateOcs2003(info, hospCode);
			 }else if(DataRowState.DELETED.getValue().equalsIgnoreCase(info.getRowState())){
					String spName="";
					if(!StringUtils.isEmpty(info.getSourceOrdKey())){
						spName=ocs1003Repository.callPrOcsUpdateDcYn(hospCode, "I",CommonUtils.parseDouble(info.getSourceOrdKey()));
					}
					if(info.getNdayYn().equalsIgnoreCase("Y")){
						spName=ocs2003Repository.callPrOcsDeleteNdayOrder(hospCode,CommonUtils.parseDouble(info.getPkocskey()));
					}
					if(!spName.equals("0")){
						throw new ExecutionException(response.build());
					}
					//delete Ocs2003
					result=ocs2003Repository.deleteOCS0103U13SaveLayout(hospCode,CommonUtils.parseDouble(info.getPkocskey()));
			 }
		}
		response.setSuccess(result != null && result > 0);
		return response.build();
	}
	
	public void insertOcs2003(OCS0103U10SaveLayoutInfo info,Double seq,Double pkocskey, String hospCode){
		Ocs2003 ocs2003 = new Ocs2003();
		ocs2003.setSysDate(new Date());
		ocs2003.setSysId(info.getUserId());
		ocs2003.setUpdDate(new Date()); 
		ocs2003.setUpdId(info.getUserId()); 
		ocs2003.setHospCode(hospCode); 
		ocs2003.setPkocs2003(pkocskey); 
		ocs2003.setBunho(info.getBunho());
		if (!StringUtils.isEmpty(info.getOrderDate()) && DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD) != null) {
			ocs2003.setOrderDate(DateUtil.toDate(info.getOrderDate(), DateUtil.PATTERN_YYMMDD)); 
        } 
		ocs2003.setOrderTime(DateUtil.getCurrentHH24MI());  
		ocs2003.setDoctor(info.getDoctor());   
		ocs2003.setInputId(info.getInputId());  
		ocs2003.setInputPart(info.getInputPart());   
		ocs2003.setInputGubun(info.getInputGubun());   
		ocs2003.setSeq(seq);   
		ocs2003.setResident(info.getDoctor());   
		ocs2003.setHangmogCode(info.getHangmogCode());  
		ocs2003.setGroupSer(CommonUtils.parseDouble(info.getGroupSer()));   
		ocs2003.setSlipCode(info.getSlipCode());   
		ocs2003.setNdayYn(info.getNdayYn());   
		ocs2003.setOrderGubun(info.getOrderGubun());   
		ocs2003.setSpecimenCode(info.getSpecimenCode());  
		ocs2003.setSuryang(CommonUtils.parseDouble(info.getSuryang()));   
		ocs2003.setOrdDanui(null); // not exist on info   
		ocs2003.setDvTime(info.getDvTime()); 
		ocs2003.setDv(CommonUtils.parseDouble(info.getDv()));   
		ocs2003.setNalsu(CommonUtils.parseDouble(info.getNalsu()));  
		ocs2003.setJusa(null);  //temp fix jusa =1 
		ocs2003.setBogyongCode(info.getBogyongCode());   
		ocs2003.setEmergency(info.getEmergency());   
		ocs2003.setJaeryoJundalYn(info.getJaeryoJundalYn());   
		ocs2003.setJundalTable(info.getJundalTable());  
		ocs2003.setJundalPart(info.getJundalPart());   
		ocs2003.setMovePart(info.getMovePart());   
		ocs2003.setMuhyo(info.getMuhyo());   
		ocs2003.setPortableYn(info.getPortableYn());   
		ocs2003.setAntiCancerYn("N");  
		ocs2003.setPay(info.getPay());
		if (!StringUtils.isEmpty(info.getReserDate()) && DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD) != null) {
			ocs2003.setReserDate(DateUtil.toDate(info.getReserDate(), DateUtil.PATTERN_YYMMDD));   
        }    
		ocs2003.setReserTime(info.getReserTime());   
		ocs2003.setDcYn(info.getDcYn());   
		ocs2003.setDcGubun(info.getDcGubun());  
		ocs2003.setBannabYn(info.getBannabYn());  
		ocs2003.setBannabConfirm(info.getBannabConfirm()); 
		ocs2003.setActDoctor(info.getActDoctor());   
		ocs2003.setActGwa(info.getActGwa());   
		ocs2003.setActBuseo(info.getActBuseo());  
		ocs2003.setOcsFlag(info.getOcsFlag());   
		ocs2003.setSgCode(info.getSgCode()); 
		if (!StringUtils.isEmpty(info.getSgYmd()) && DateUtil.toDate(info.getSgYmd(), DateUtil.PATTERN_YYMMDD) != null) {
			ocs2003.setSgYmd(DateUtil.toDate(info.getSgYmd(), DateUtil.PATTERN_YYMMDD));    
        }   
		ocs2003.setIoGubun(info.getIoGubun());   
		ocs2003.setBichiYn(info.getBichiYn());  
		ocs2003.setDrgBunho(CommonUtils.parseDouble(info.getDrgBunho()));   
		ocs2003.setSubSusul(null);  //temp fix 
		ocs2003.setWonyoiOrderYn(info.getWonyoiOrderYn());   
		ocs2003.setPowderYn(info.getPowderYn()); 
		if (!StringUtils.isEmpty(info.getHopeDate()) && DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD) != null) {
			ocs2003.setHopeDate(DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD));     
        } 
		ocs2003.setHopeTime(info.getHopeTime());   
		ocs2003.setDv1(CommonUtils.parseDouble(info.getDv1()));   
		ocs2003.setDv2(CommonUtils.parseDouble(info.getDv2()));   
		ocs2003.setDv3(CommonUtils.parseDouble(info.getDv3()));   
		ocs2003.setDv4(CommonUtils.parseDouble(info.getDv4()));   
		ocs2003.setMixGroup(info.getMixGroup());  
		ocs2003.setOrderRemark(info.getOrderRemark());   
		ocs2003.setNurseRemark(info.getNurseRemark());   
		ocs2003.setBomOccurYn(info.getBomOccurYn());   
		ocs2003.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));   
		ocs2003.setDisplayYn("Y");   
		ocs2003.setNurseConfirmUser(info.getNurseConfirmUser());
		if (!StringUtils.isEmpty(info.getNurseConfirmDate()) && DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD) != null) {
			ocs2003.setNurseConfirmDate(DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD));    
        }   
		ocs2003.setNurseConfirmTime(info.getNurseConfirmTime());  
		ocs2003.setTelYn(info.getTelYn());   
		ocs2003.setRegularYn(info.getRegularYn());   
		ocs2003.setInputTab(info.getInputTab());  
		ocs2003.setHubalChangeYn(info.getHubalChangeYn());   
		ocs2003.setPharmacy(info.getPharmacy());  
		ocs2003.setInputDoctor(info.getInputDoctor());   
		ocs2003.setJusaSpdGubun(info.getJusaSpdGubun());   
		ocs2003.setDrgPackYn(info.getDrgPackYn());  
		ocs2003.setSortFkocskey(CommonUtils.parseDouble(info.getSortFkocskey()));  
		ocs2003.setFkinp1001(CommonUtils.parseDouble(info.getInOutKey()));   
		ocs2003.setInputGwa(info.getInputGwa());   
		ocs2003.setNdayOccurYn("N");
		ocs2003.setDv5(CommonUtils.parseDouble(info.getDv5()));
		ocs2003.setDv6(CommonUtils.parseDouble(info.getDv6()));
		ocs2003.setDv7(CommonUtils.parseDouble(info.getDv7()));
		ocs2003.setDv8(CommonUtils.parseDouble(info.getDv8()));
		ocs2003.setBogyongCodeSub(info.getBogyongCode());
		ocs2003Repository.save(ocs2003);
	}
	public Integer updateOcs2003(OCS0103U10SaveLayoutInfo info, String hospCode){
		try {
			List<Ocs2003> listOcs2003 =ocs2003Repository.listOcs2003OCS0103U13SaveLayout(hospCode,CommonUtils.parseDouble(info.getPkocskey()));
			if(!CollectionUtils.isEmpty(listOcs2003)) {
				for(Ocs2003 ocs2003 : listOcs2003) {
					ocs2003.setUpdDate(new Date());
					ocs2003.setUpdId(info.getUserId());
					ocs2003.setOrderGubun(info.getOrderGubun()); 
					ocs2003.setSuryang(CommonUtils.parseDouble(info.getSuryang())); 
					ocs2003.setDvTime(info.getDvTime()); 
					ocs2003.setDv(CommonUtils.parseDouble(info.getDv()));   
					ocs2003.setNdayYn(info.getNdayYn());  
					ocs2003.setNalsu(CommonUtils.parseDouble(info.getNalsu()));  
					ocs2003.setJusa(info.getJusa()); 
					ocs2003.setBogyongCode(info.getBogyongCode());   
					ocs2003.setEmergency(info.getEmergency());   
					ocs2003.setJaeryoJundalYn(info.getJaeryoJundalYn());   
					ocs2003.setJundalTable(info.getJundalTable());  
					ocs2003.setJundalPart(info.getJundalPart());   
					ocs2003.setMovePart(info.getMovePart());   
					ocs2003.setMuhyo(info.getMuhyo());   
					ocs2003.setPortableYn(info.getPortableYn());   
					ocs2003.setAntiCancerYn(info.getAntiCancerYn());  
					ocs2003.setDcYn(info.getDcYn());   
					ocs2003.setDcGubun(info.getDcGubun());  
					ocs2003.setBannabYn(info.getBannabYn());  
					ocs2003.setBannabConfirm(info.getBannabConfirm()); 
					ocs2003.setPowderYn(info.getPowderYn()); 
					if (!StringUtils.isEmpty(info.getHopeDate()) && DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD) != null) {
						ocs2003.setHopeDate(DateUtil.toDate(info.getHopeDate(), DateUtil.PATTERN_YYMMDD));     
			        } 
					ocs2003.setHopeTime(info.getHopeTime());   
					ocs2003.setDv1(CommonUtils.parseDouble(info.getDv1()));   
					ocs2003.setDv2(CommonUtils.parseDouble(info.getDv2()));   
					ocs2003.setDv3(CommonUtils.parseDouble(info.getDv3()));   
					ocs2003.setDv4(CommonUtils.parseDouble(info.getDv4())); 
					ocs2003.setDv5(CommonUtils.parseDouble(info.getDv5()));   
					ocs2003.setDv6(CommonUtils.parseDouble(info.getDv6()));   
					ocs2003.setDv7(CommonUtils.parseDouble(info.getDv7()));   
					ocs2003.setDv8(CommonUtils.parseDouble(info.getDv8()));   
					ocs2003.setMixGroup(info.getMixGroup());  
					ocs2003.setOrderRemark(info.getOrderRemark());   
					ocs2003.setNurseRemark(info.getNurseRemark());   
					ocs2003.setBomOccurYn(info.getBomOccurYn());   
					ocs2003.setBomSourceKey(CommonUtils.parseDouble(info.getBomSourceKey()));
					ocs2003.setNurseConfirmUser(info.getNurseConfirmUser());
					if (!StringUtils.isEmpty(info.getNurseConfirmDate()) && DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD) != null) {
						ocs2003.setNurseConfirmDate(DateUtil.toDate(info.getNurseConfirmDate(), DateUtil.PATTERN_YYMMDD));    
			        }   
					ocs2003.setNurseConfirmTime(info.getNurseConfirmTime());  
					ocs2003.setRegularYn(info.getRegularYn());   
					ocs2003.setHubalChangeYn(info.getHubalChangeYn());   
					ocs2003.setPharmacy(info.getPharmacy()); 
					ocs2003.setJusaSpdGubun(info.getJusaSpdGubun());   
					ocs2003.setDrgPackYn(info.getDrgPackYn());  
					ocs2003.setSortFkocskey(CommonUtils.parseDouble(info.getSortFkocskey()));    
					ocs2003.setWonyoiOrderYn(info.getWonyoiOrderYn());
					if(ocs2003.getDcGubun().equals("Y") && ocs2003.getSortFkocskey() !=null && info.getDcGubun().equals("N")){
						ocs2003.setDisplayYn("N"); 
					}
					ocs2003.setSpecimenCode(info.getSpecimenCode());
				}
			}
			ocs2003Repository.save(listOcs2003);
			return 1;
		} catch (Exception e) {
			LOGGER.error("Error on updateOcs2003 "+e.getMessage(), e);
			return 0;
		}
	}
}