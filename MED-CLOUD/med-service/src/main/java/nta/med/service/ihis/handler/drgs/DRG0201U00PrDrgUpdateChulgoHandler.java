package nta.med.service.ihis.handler.drgs;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.config.Configuration;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.inv.Inv2003;
import nta.med.core.domain.inv.Inv2004;
import nta.med.core.domain.inv.Inv4001;
import nta.med.core.domain.inv.Inv4002;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.drg.Drg2010Repository;
import nta.med.data.dao.medi.inv.Inv0001Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.service.ihis.proto.DrgsModelProto;
import nta.med.service.ihis.proto.DrgsModelProto.DRG0201U00InventoryInfo;
import nta.med.service.ihis.proto.DrgsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class DRG0201U00PrDrgUpdateChulgoHandler extends ScreenHandler<DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest, SystemServiceProto.UpdateResponse> {
    private static final Log LOG = LogFactory.getLog(DRG0201U00PrDrgUpdateChulgoHandler.class);
    
    @Resource
    private Drg2010Repository drg2010Repository;

    @Resource
    private Inv0001Repository inv0001Repository;
    
    @Resource
    private Inv2003Repository inv2003Repository;
    
    @Resource
    private Inv2004Repository inv2004Repository;
    
    @Resource
    private CommonRepository commonRepository;
    
    @Resource
    private Bas0102Repository bas0102Repository;
    
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Resource
    private Inv4001Repository inv4001Repository;
    
    @Resource
    private Inv4002Repository inv4002Repository;
    
    @Resource
    private Inv0110Repository inv0110Repository;
    
    @Resource
    private Ocs1003Repository ocs1003Repository;
    
    @Resource
    private Inv0102Repository inv0102Repository;
    @Resource
	private Configuration configuration;
    @Resource
    private Bas0001Repository bas0001Repository;
    
    @Override
    public boolean isValid(DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest request, Vertx vertx, String clientId, String sessionId) {
        if(!StringUtils.isEmpty(request.getJubsuDate()) && DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        } else if(!StringUtils.isEmpty(request.getChulgoDate()) && DateUtil.toDate(request.getChulgoDate(), DateUtil.PATTERN_YYMMDD) == null){
            return false;
        }
        return true;
    }

    @Override
    @Transactional(rollbackFor = Throwable.class)
    public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId, DrgsServiceProto.DRG0201U00PrDrgUpdateChulgoRequest request) throws Exception {
        SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
        String oErr = drg2010Repository.callPrDrgUpdateChulgo(getHospitalCode(vertx, sessionId),
                DateUtil.toDate(request.getJubsuDate(), DateUtil.PATTERN_YYMMDD),
                CommonUtils.parseInteger(request.getDrgBunho()),
                DateUtil.toDate(request.getChulgoDate(), DateUtil.PATTERN_YYMMDD),
                request.getActUser(),
                request.getChulgoBuseo(),
                request.getWonyoiOrderYn(),
                request.getActYn());
        if (oErr.equals("0")) {
            response.setResult(true);
            
            // Update ACT_DOCTOR
            List<DrgsModelProto.DRG0201U00InventoryInfo> ords = request.getLstList();
            if(!CollectionUtils.isEmpty(ords)){
            	for (DRG0201U00InventoryInfo ord : ords) {
            		ocs1003Repository.updateActDoctor(getHospitalCode(vertx, sessionId), CommonUtils.parseDouble(ord.getFkocs1003()), request.getActUser());
				}
            }
            
            // [START] Inventory Logic
            boolean invUsage = false;
            String hospCode = getHospitalCode(vertx, sessionId);
            String language = getLanguage(vertx, sessionId);
            String userId = getUserId(vertx, sessionId);
    		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, "INV_USAGE");
    		
    		if(!CollectionUtils.isEmpty(bas0102List)){
    			if("Y".equals(bas0102List.get(0).getCode())){
    				invUsage = true;
    			}
    		}
            
    		if(invUsage){
    			List<DrgsModelProto.DRG0201U00InventoryInfo> orderList = request.getLstList();
    			List<DrgsModelProto.DRG0201U00InventoryInfo> orderDistinctList = new ArrayList<DrgsModelProto.DRG0201U00InventoryInfo>();
    			
    			if(!CollectionUtils.isEmpty(orderList)){
    				Map<String, String> mapInvsYn = new HashMap<String, String>();
    				for (DRG0201U00InventoryInfo order : orderList) {
    					String invYn = inv0110Repository.checkInvenByHangmogCode(hospCode, order.getJaeryoCode());
    					invYn = invYn == null ? "N" : invYn;
    					mapInvsYn.put(order.getJaeryoCode(), invYn);
    					
    					DrgsModelProto.DRG0201U00InventoryInfo existOrder = getExitsOrderByJaeryoCode(orderDistinctList, order.getJaeryoCode()); 
    					if(existOrder == null){
    						orderDistinctList.add(order);
    					} else {
    						int countQty = CommonUtils.parseInteger(order.getOrdSuryang()) + CommonUtils.parseInteger(existOrder.getOrdSuryang());
    						removeByJaeryoCode(orderDistinctList, order.getJaeryoCode());
    						DrgsModelProto.DRG0201U00InventoryInfo newOrder = existOrder.toBuilder().setOrdSuryang(String.valueOf(countQty)).build();
    						orderDistinctList.add(newOrder);
    					}
					}
    				
    				String remark = "";
    				boolean invsMaster = false;
					if(!CollectionUtils.isEmpty(orderDistinctList)){
						for (DRG0201U00InventoryInfo info : orderDistinctList) {
    						if("Y".equals(mapInvsYn.get(info.getJaeryoCode()))){
    							remark = ocs1003Repository.getRemarkOcs1003(hospCode, CommonUtils.parseDouble(info.getFkocs1003()), null, language);
    							invsMaster = true;
    							break;
    						} 
						}
					}
//					get local time zone
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
					
					SimpleDateFormat localTimeFormat = new SimpleDateFormat("HHmm");
					String churiTime = localTimeFormat.format(sysDate);
					
    				if("Y".equals(request.getActYn()) && mapInvsYn.size() > 0 && invsMaster){
    					Inv2003 inv2003 = insertInv2003(hospCode, userId, remark, language, churiTime, sysDate);
        				if (inv2003 != null && inv2003.getPkinv2003() != null) {
        					for (DRG0201U00InventoryInfo info : orderDistinctList) {
        						if("Y".equals(mapInvsYn.get(info.getJaeryoCode()))){
        							int countUpd = inv0001Repository.setActiveInv0001(hospCode, CommonUtils.parseDouble(info.getFkocs1003()), userId, new BigDecimal(0));
            						if(countUpd > 0) insertInv2004(hospCode, userId, inv2003.getPkinv2003(), info);
        						}
    						}
        				}
        			} else if("N".equals(request.getActYn()) && mapInvsYn.size() > 0 && invsMaster){
        				Inv4001 inv4001 = insertInv4001(hospCode, language, userId, remark, churiTime);
        				if(inv4001 != null && inv4001.getPkinv4001() != null){
        					for (DRG0201U00InventoryInfo info : orderDistinctList) {
        						if("Y".equals(mapInvsYn.get(info.getJaeryoCode()))){
        							int countUpd = inv0001Repository.setActiveInv0001(hospCode, CommonUtils.parseDouble(info.getFkocs1003()), userId, new BigDecimal(1));
            						if(countUpd > 0) insertInv4002(hospCode, userId, inv4001.getPkinv4001(), info);
        						}
    						}
        				}
        			}
    				
                }
    		}
    		// [END] Inventory Logic
    		
        } else {
            response.setResult(false);
        }
        
        return response.build();
    }
    
    private Inv2003 insertInv2003(String hospCode, String userId, String remark, String language, String churiTime, Date sysDate ){
		Inv2003 inv2003 = new Inv2003();
		Double pkinv2003 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2003_SEQ"));
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		List<Adm3200> admList = adm3200Repository.findByHospCodeUserId(hospCode, userId);
		String churiBuseo = CollectionUtils.isEmpty(admList) ? "" : admList.get(0).getDeptCode();
		
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String exportCode = CollectionUtils.isEmpty(listCodeName) ? String.valueOf(churiSeq).split("\\.")[0] : listCodeName.get(0) + String.valueOf(churiSeq).split("\\.")[0];
		
		inv2003.setPkinv2003(pkinv2003);
		inv2003.setSysDate(sysDate);
		inv2003.setSysId(userId);
		inv2003.setUpdDate(sysDate);
		inv2003.setHospCode(hospCode);
//		inv2003.setChuriDate(new Date());
		inv2003.setChuriDate(sysDate);
		inv2003.setChuriBuseo(churiBuseo);
		inv2003.setChulgoType("ORD");
		inv2003.setChuriSeq(churiSeq);
		inv2003.setIpchulType("O");
		inv2003.setRemark(remark);
		inv2003.setExportCode(exportCode);
		inv2003.setChuriTime(churiTime);
		
		inv2003Repository.save(inv2003);
		return inv2003;
	}
    
	private Inv2004 insertInv2004(String hospCode, String userId, Double fkInv2003, DrgsModelProto.DRG0201U00InventoryInfo info){
		Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
		
		Inv2004 inv2004 = new Inv2004();
		inv2004.setPkinv2004(pkinv2004);
		inv2004.setSysDate(new Date());
		inv2004.setSysId(userId);
		inv2004.setUpdDate(new Date());
		inv2004.setUpdId(userId);
		inv2004.setHospCode(hospCode);
		inv2004.setFkinv2003(fkInv2003);
		inv2004.setJaeryoCode(info.getJaeryoCode());
		inv2004.setChulgoQty(commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(info.getNalsu()), CommonUtils.parseDouble(info.getOrdSuryang()), CommonUtils.parseDouble(info.getDv()), info.getDvTime()));
		//inv2004.setChulgoQty(CommonUtils.parseDouble(info.getOrdSuryang())*CommonUtils.parseDouble(info.getDv())*CommonUtils.parseDouble(info.getNalsu()));
		
		inv2004Repository.save(inv2004);
		return inv2004;
	}
	
	private Inv4001 insertInv4001(String hospCode, String language, String userId, String remark, String churiTime){
		Inv4001 inv4001 = new Inv4001();
		List<Adm3200> admList = adm3200Repository.findByHospCodeUserId(hospCode, userId);
		String churiBuseo = CollectionUtils.isEmpty(admList) ? "" : admList.get(0).getDeptCode();
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		Double pkInv4001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4001_SEQ")); // refer INV4001NextSeqHandler
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String importCode = CollectionUtils.isEmpty(listCodeName) ? String.format("%.0f", churiSeq) : listCodeName.get(0) + String.format("%.0f", churiSeq);
		
		inv4001.setPkinv4001(pkInv4001);
		inv4001.setSysDate(new Date());
		inv4001.setSysId(userId);
		inv4001.setUpdDate(new Date());
		inv4001.setUpdId(userId);
		inv4001.setHospCode(hospCode);
		inv4001.setChuriDate(new Date());
		inv4001.setChuriBuseo(churiBuseo);
		inv4001.setIpgoType("RET");
		inv4001.setChuriSeq(churiSeq);
		inv4001.setIpchulType("I");
		inv4001.setImportCode(importCode);
		inv4001.setChuriTime(churiTime);
		inv4001.setRemark(remark);
		
		inv4001Repository.save(inv4001);
		return inv4001;
	}
    
	private Inv4002 insertInv4002(String hospCode, String userId, Double fkInv4001, DrgsModelProto.DRG0201U00InventoryInfo info){
		Inv4002 inv4002 = new Inv4002();
		Double pkInv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
		
		inv4002.setPkinv4002(pkInv4002);
		inv4002.setLot("");
		inv4002.setExpiredDate(DateUtil.toDate("9999/12/31", DateUtil.PATTERN_YYMMDD));
		
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setFkinv4001(fkInv4001);
		inv4002.setJaeryoCode(info.getJaeryoCode());
		//inv4002.setIpgoQty(CommonUtils.parseDouble(info.getOrdSuryang())*CommonUtils.parseDouble(info.getDv())*CommonUtils.parseDouble(info.getNalsu()));
		inv4002.setIpgoQty(commonRepository.callFnDrgWonyoiTotSurang(CommonUtils.parseDouble(info.getNalsu()), CommonUtils.parseDouble(info.getOrdSuryang()), CommonUtils.parseDouble(info.getDv()), info.getDvTime()));
		inv4002Repository.save(inv4002);
		return inv4002;
	}
	
	private DrgsModelProto.DRG0201U00InventoryInfo getExitsOrderByJaeryoCode(List<DrgsModelProto.DRG0201U00InventoryInfo> listOrder, String jaeryoCode){
		for (DRG0201U00InventoryInfo order : listOrder) {
			if(jaeryoCode.equals(order.getJaeryoCode())){
				return order;
			}
		}
		
		return null;
	}
	
	private void removeByJaeryoCode(List<DrgsModelProto.DRG0201U00InventoryInfo> listOrder, String jaeryoCode){
		for (Iterator<DrgsModelProto.DRG0201U00InventoryInfo> it = listOrder.iterator(); it.hasNext(); ) {
			DrgsModelProto.DRG0201U00InventoryInfo order = it.next();
		    if (jaeryoCode.equals(order.getJaeryoCode())) {
		        it.remove();
		    }
		}
	}
}
