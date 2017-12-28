package nta.med.service.ihis.handler.injs;

import java.math.BigDecimal;
import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.inv.Inv2003;
import nta.med.core.domain.inv.Inv2004;
import nta.med.core.domain.inv.Inv4001;
import nta.med.core.domain.inv.Inv4002;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.data.dao.medi.inv.Inv0001Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.service.ihis.proto.InjsModelProto.INJ1001U01SaveLayoutInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.core.config.Configuration;

@Service                                                                                                          
@Scope("prototype")   
@Transactional
public class INJ1001U01SaveLayoutHandler extends ScreenHandler<InjsServiceProto.INJ1001U01SaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ1001U01SaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Inj1001Repository inj1001Repository;  
	@Resource
	private Inj1002Repository inj1002Repository;
	@Resource
	private Inv2003Repository inv2003Repository;
	@Resource
	private Inv2004Repository inv2004Repository;
	@Resource
	private Inv0001Repository inv0001Repository;
	@Resource
	private CommonRepository commonRepository;
	@Resource
	private Inv4001Repository inv4001Repository;
	@Resource
	private Inv4002Repository inv4002Repository;
	@Resource
	private Adm3200Repository adm3200Repository;
	@Resource
	private Inv0110Repository inv0110Repository;
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
	private Ocs1003Repository ocs1003Repository;
	
    @Resource
    private Inv0102Repository inv0102Repository;
    @Resource
    private Bas0001Repository bas0001Repository;
    @Resource
    private Configuration configuration;
	
	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();  
		Integer resultUpdate = null;
  	   	String msg = null;
  	    String temp1 = null;
		String temp2 = null;
		String hospCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String userId = request.getUpdId();
		String churiBuseo = "";
		List<Adm3200> adm3200s = adm3200Repository.getAdm3200ByUserId(hospCode, userId);
		if(!CollectionUtils.isEmpty(adm3200s)){
			churiBuseo = adm3200s.get(0).getDeptCode();
		}
		// check hospital using inventory or not
        List<ComboListItemInfo> combos = bas0102Repository.getComboListItemInfoByCodeType(hospCode, getLanguage(vertx, sessionId), "INV_USAGE");
        boolean isHosCodeInv = combos.size() > 0 && "Y".equals(combos.get(0).getCode());
//		get local time zone
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
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		String churiTime = localDateFormat.format(sysDate);
		for(INJ1001U01SaveLayoutInfo info: request.getSaveLayoutItemList()){
			//check
		  List<Timestamp> listObject = inj1001Repository.getInjsINJ1001U01OrderDateList(hospCode, info.getPkinj1002());
          if(!CollectionUtils.isEmpty(listObject)) {
          	for(Timestamp item : listObject) {
          		//response.addOrderDate(item == null ? "" : DateUtil.toString(item, DateUtil.PATTERN_YYMMDD));
          		if(item != null && item.toString().length() > 9){
          			String orderDate=item.toString();
          			temp1 = orderDate.substring(0, 10).replace("/", "").replace("-","");
          		}
          			temp2 = info.getActingDate().replace("/","").replace("-","");
          		if(StringUtils.isEmpty(temp2)){
          			temp2 = "30001231";
          		}
          		if(CommonUtils.parseInteger(temp1) > CommonUtils.parseInteger(temp2)){
          			msg = info.getHangmogName();
          			if(!StringUtils.isEmpty(msg)){
    					response.setMsg(msg);
    				}
          			response.setResult(false);
          			throw new ExecutionException(response.build());
          		}
          	}	
          }
          //update
          Double pkinj1002 = CommonUtils.parseDouble(info.getPkinj1002());
          Double fkocs1003 = CommonUtils.parseDouble(info.getFkocs1003());
          String jaeryoCode = info.getHangmogCode();
          String hangmogInventoryYn = inv0110Repository.checkInvenByHangmogCode(hospCode, jaeryoCode);
          Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
      	  Double ipgoQty = commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(info.getNalsu()), CommonUtils.parseDouble(info.getSuryang()), CommonUtils.parseDouble(info.getDv()), "*");
          //Double ipgoQty = CommonUtils.parseDouble(info.getSuryang()) * CommonUtils.parseDouble(info.getDv()) * CommonUtils.parseDouble(info.getNalsu()); 
          if("Y".equals(info.getActingFlag())){
          	Date actingDate = DateUtil.toDate(info.getActingDate(), DateUtil.PATTERN_YYMMDD);
          	resultUpdate = inj1002Repository.updateINJ1001U01(info.getActingFlag(), actingDate, DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM),
	            		info.getTonggyeCode(), info.getMixGroup(), request.getUpdId(), new Date(), info.getJujongja(), info.getSilsiRemark(), hospCode, pkinj1002);
          	
          	if(isHosCodeInv && YesNo.YES.getValue().equals(hangmogInventoryYn)){
                 Double pkinv2003 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2003_SEQ"));
                 Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
          		inventoryHistoryCaseTick(hospCode, userId, churiBuseo, churiSeq, pkinv2003, pkinv2004, jaeryoCode, ipgoQty, fkocs1003, language, churiTime);
          	}
          	
          }else{
          	resultUpdate = inj1002Repository.updateINJ1001U01(info.getActingFlag(), null, null,
	            		info.getTonggyeCode() , info.getMixGroup(), request.getUpdId(), new Date(), null, info.getSilsiRemark(), hospCode, pkinj1002);
          	if(isHosCodeInv && YesNo.YES.getValue().equals(hangmogInventoryYn)){
          		Double pkinv4001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4001_SEQ"));
                Double pkinv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
          		inventoryHistoryCaseUnTick(hospCode, language, userId, churiBuseo, churiSeq, pkinv4001, ipgoQty, fkocs1003, jaeryoCode, pkinv4002, churiTime);
          	}
          }
		}
		response.setResult(resultUpdate != null && resultUpdate > 0);
		return response.build();
	}
	
	private void inventoryHistoryCaseTick(String hospCode, String userId, String churiBuseo, Double churiSeq, Double pkinv2003, Double pkinv2004,
			String jaeryoCode, Double chulgoQty, Double fkocs1003, String language, String churiTime){
		
		inv0001Repository.updateInv0001(userId, new BigDecimal("0"), hospCode, fkocs1003);
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
		
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String exportCode = CollectionUtils.isEmpty(listCodeName) ? String.valueOf(churiSeq).split("\\.")[0] : listCodeName.get(0) + String.valueOf(churiSeq).split("\\.")[0];
		
		Inv2003 inv2003 = new Inv2003();
		inv2003.setSysDate(new Date());
		inv2003.setSysId(userId);
		inv2003.setUpdDate(new Date());
		inv2003.setUpdId(userId);
		inv2003.setHospCode(hospCode);
		inv2003.setChuriDate(new Date());
		inv2003.setChuriBuseo(churiBuseo);
		inv2003.setChulgoType("ORD");
		inv2003.setChuriSeq(churiSeq);
		inv2003.setPkinv2003(pkinv2003);
		inv2003.setIpchulType("O");
		inv2003.setRemark(remark);
		inv2003.setExportCode(exportCode);
		inv2003.setChuriTime(churiTime);
		
		inv2003Repository.save(inv2003);
		
		Inv2004 inv2004 = new Inv2004();
		inv2004.setSysDate(new Date());
		inv2004.setSysId(userId);
		inv2004.setUpdDate(new Date());
		inv2004.setHospCode(hospCode);
		inv2004.setFkinv2003(pkinv2003);
		inv2004.setJaeryoCode(jaeryoCode);
		inv2004.setChulgoQty(chulgoQty);
		inv2004.setPkinv2004(pkinv2004);
		inv2004Repository.save(inv2004);
	}
	private void inventoryHistoryCaseUnTick(String hospCode, String language, String userId, String churiBuseo, 
			Double churiSeq, Double pkinv4001, Double ipgoQty, Double fkocs1003, String jaeryoCode, Double pkinv4002, String churiTime){
		
		inv0001Repository.updateInv0001(userId, new BigDecimal("1"), hospCode, fkocs1003);
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String importCode = CollectionUtils.isEmpty(listCodeName) ? String.format("%.0f", churiSeq) : listCodeName.get(0) + String.format("%.0f", churiSeq);
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, fkocs1003, null, language);
		
		Inv4001 inv4001 = new Inv4001();
		inv4001.setSysDate(new Date());
		inv4001.setSysId(userId);
		inv4001.setUpdDate(new Date());
		inv4001.setUpdId(userId);
		inv4001.setHospCode(hospCode);
		inv4001.setChuriDate( new Date());
		inv4001.setChuriBuseo(churiBuseo);
		inv4001.setIpgoType("RET");
		inv4001.setChuriSeq(churiSeq);
		inv4001.setIpchulType("I");
		inv4001.setPkinv4001(pkinv4001);
		inv4001.setImportCode(importCode);
		inv4001.setChuriTime(churiTime);
		inv4001.setRemark(remark);
		inv4001Repository.save(inv4001);
		
		Inv4002 inv4002 = new Inv4002();
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setFkinv4001(pkinv4001);
		inv4002.setJaeryoCode(jaeryoCode);
		inv4002.setIpgoQty(ipgoQty);
		inv4002.setPkinv4002(pkinv4002);
		inv4002.setLot("10");
		inv4002.setExpiredDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		inv4002Repository.save(inv4002);
	}
}