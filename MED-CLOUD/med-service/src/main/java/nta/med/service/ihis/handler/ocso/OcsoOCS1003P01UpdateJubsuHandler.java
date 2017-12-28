package nta.med.service.ihis.handler.ocso;

import java.math.BigDecimal;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
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

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.adm.Adm3200;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.bas.Bas0102;
import nta.med.core.domain.inv.Inv2003;
import nta.med.core.domain.inv.Inv2004;
import nta.med.core.domain.inv.Inv4001;
import nta.med.core.domain.inv.Inv4002;
import nta.med.core.domain.ocs.Ocs1003;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.adm.Adm3200Repository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.bas.Bas0102Repository;
import nta.med.data.dao.medi.inv.Inv0001Repository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv0110Repository;
import nta.med.data.dao.medi.inv.Inv2003Repository;
import nta.med.data.dao.medi.inv.Inv2004Repository;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.out.Out1001Repository;
import nta.med.service.ihis.proto.OcsoServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

@Service
@Scope("prototype")
public class OcsoOCS1003P01UpdateJubsuHandler extends ScreenHandler<OcsoServiceProto.OcsoOCS1003P01UpdateJubsuRequest, SystemServiceProto.UpdateResponse> {
	private static final Log LOGGER = LogFactory.getLog(OcsoOCS1003P01UpdateJubsuHandler.class);
	
	@Resource
	private Out1001Repository out1001Repository;

	@Resource
	private Ocs1003Repository ocs1003Repository;
	
	@Resource
	private Configuration configuration;
	
	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private Inv0001Repository inv0001Repository;
	
	@Resource
	private Bas0102Repository bas0102Repository;
	
	@Resource
    private Inv2003Repository inv2003Repository;
    
    @Resource
    private Inv2004Repository inv2004Repository;
	
    @Resource
    private Inv0102Repository inv0102Repository;
    
    @Resource
    private Adm3200Repository adm3200Repository;
    
    @Resource
    private Inv0110Repository inv0110Repository;
    
    @Resource
    private Inv4001Repository inv4001Repository;
    
    @Resource
    private Inv4002Repository inv4002Repository;
    
	@Override
	@Transactional(rollbackFor = Throwable.class)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsoOCS1003P01UpdateJubsuRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		Double fkout1001 = CommonUtils.parseDouble(request.getPkNaewonKey());
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		boolean isCancel = false;
		
		List<String> listNaewonYn = out1001Repository.OcsaOCS0503U00GetNaewonYn(hospCode, fkout1001);
		if(!CollectionUtils.isEmpty(listNaewonYn) && "E".equals(listNaewonYn.get(0)) && "Y".equals(request.getNaewonYn())){
			isCancel = true;
		}
		
		boolean result = updateOcsoOCS1003P01JubsuInfo(request, getHospitalCode(vertx, sessionId));
		if(!result) return response.setResult(false).build();
		
		// get acting date
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
		Date localDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		Date actingDate = DateUtil.toDate(new SimpleDateFormat(DateUtil.PATTERN_YYMMDD).format(localDate), DateUtil.PATTERN_YYMMDD);
		
		// get auto execute order list and filter inventory order
		List<Ocs1003> orderList = ocs1003Repository.findByHospCodeFkout1001(hospCode, new BigDecimal(fkout1001));
		List<Ocs1003> autoExecuteOrderList = new ArrayList<Ocs1003>();
		List<Double> pkocs1003List = new ArrayList<Double>();
		Map<Double, String> mapJaeryoCode = new HashMap<Double, String>();
		
		if(CollectionUtils.isEmpty(orderList)) 
			return response.setResult(true).build();
		
		for (Ocs1003 order : orderList) {
			if("HOM".equals(order.getMovePart()) || "Y".equals(order.getWonyoiOrderYn())){
				String jaeryoCode = inv0110Repository.findJaeryoCode(hospCode, order.getHangmogCode());
				if (!StringUtils.isEmpty(jaeryoCode))
					mapJaeryoCode.put(order.getPkocs1003(), jaeryoCode);
				
				pkocs1003List.add(order.getPkocs1003());
				autoExecuteOrderList.add(order);
			}
		}
		
		// update acting date
		if(CollectionUtils.isEmpty(autoExecuteOrderList))
			return response.setResult(true).build();
		
		actingDate = "E".equals(request.getNaewonYn()) ? actingDate : null;	// NaewonYn = E/Y 
		Integer rowUpdated = ocs1003Repository.updateActingDate(actingDate, hospCode, pkocs1003List);
		if(rowUpdated <= 0)
			throw new ExecutionException(response.setResult(false).build());
		
		// check using inventory
		List<Bas0102> bas0102List = bas0102Repository.findByHospCodeAndCodeType(hospCode, "INV_USAGE");
		if(CollectionUtils.isEmpty(bas0102List) || !"Y".equals(bas0102List.get(0).getCode())){
			response.setResult(true);
			return response.build();
		}
		
		// auto export/import inventory
		String remark = ocs1003Repository.getRemarkOcs1003(hospCode, null, fkout1001, language);
		if ("E".equals(request.getNaewonYn()) && mapJaeryoCode.size() > 0) {
			Inv2003 inv2003 = insertInv2003(hospCode, userId, localTimeZone, remark, language);
			if(inv2003 != null && inv2003.getPkinv2003() != null){
				for (Ocs1003 ocs1003 : autoExecuteOrderList) {
					String jaeryoCode = mapJaeryoCode.get(ocs1003.getPkocs1003());
					if(!StringUtils.isEmpty(jaeryoCode)){
						int countUpd = inv0001Repository.setActiveInv0001(hospCode, ocs1003.getPkocs1003(), userId, new BigDecimal(0));
						if(countUpd > 0) {
							insertInv2004(hospCode, userId, inv2003.getPkinv2003(), ocs1003, jaeryoCode);
						}
					}
				}
			}
		} else if ("Y".equals(request.getNaewonYn()) && mapJaeryoCode.size() > 0 && isCancel) {
			Inv4001 inv4001 = insertInv4001(hospCode, language, userId, remark);
			if(inv4001 != null && inv4001.getPkinv4001() != null){
				for (Ocs1003 ocs1003 : autoExecuteOrderList) {
					String jaeryoCode = mapJaeryoCode.get(ocs1003.getPkocs1003());
					if(!StringUtils.isEmpty(jaeryoCode)){
						int countUpd = inv0001Repository.setActiveInv0001(hospCode, ocs1003.getPkocs1003(), userId, new BigDecimal(1));
						if(countUpd > 0) {
							insertInv4002(hospCode, userId, inv4001.getPkinv4001(), ocs1003, jaeryoCode);
						}
					}
				}
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private boolean updateOcsoOCS1003P01JubsuInfo(OcsoServiceProto.OcsoOCS1003P01UpdateJubsuRequest request, String hospCode){
		Double pkout1001 = CommonUtils.parseDouble(request.getPkNaewonKey());
		return out1001Repository.updateOcsoOCS1003P01JubsuInfo(hospCode, request.getNaewonYn(), pkout1001) > 0;
	}
	
	private Inv2003 insertInv2003(String hospCode, String userId, int localTimeZone, String remark, String language){
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		String sTime = localDateFormat.format(sysDate);
		
		Inv2003 inv2003 = new Inv2003();
		Double pkinv2003 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2003_SEQ"));
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("CHURI_SEQ"));
		List<Adm3200> admList = adm3200Repository.findByHospCodeUserId(hospCode, userId);
		String churiBuseo = CollectionUtils.isEmpty(admList) ? "" : admList.get(0).getDeptCode();
		
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String exportCode = CollectionUtils.isEmpty(listCodeName) ? String.valueOf(churiSeq).split("\\.")[0] : listCodeName.get(0) + String.valueOf(churiSeq).split("\\.")[0];
		
		inv2003.setPkinv2003(pkinv2003);
		inv2003.setSysDate(new Date());
		inv2003.setSysId(userId);
		inv2003.setUpdDate(new Date());
		inv2003.setHospCode(hospCode);
		inv2003.setChuriDate(sysDate);
		inv2003.setChuriBuseo(churiBuseo);
		inv2003.setChulgoType("ORD");
		inv2003.setChuriSeq(churiSeq);
		inv2003.setIpchulType("O");
		inv2003.setRemark(remark);
		inv2003.setExportCode(exportCode);
		inv2003.setChuriTime(sTime);
		
		inv2003Repository.save(inv2003);
		return inv2003;
	}
	
	private Inv2004 insertInv2004(String hospCode, String userId, Double fkInv2003, Ocs1003 ocs1003, String jaeryoCode){
		Double pkinv2004 = CommonUtils.parseDouble(commonRepository.getNextVal("INV2004_SEQ"));
		
		Inv2004 inv2004 = new Inv2004();
		inv2004.setPkinv2004(pkinv2004);
		inv2004.setSysDate(new Date());
		inv2004.setSysId(userId);
		inv2004.setUpdDate(new Date());
		inv2004.setUpdId(userId);
		inv2004.setHospCode(hospCode);
		inv2004.setFkinv2003(fkInv2003);
		inv2004.setJaeryoCode(jaeryoCode);
		//inv2004.setChulgoQty(ocs1003.getSuryang()*ocs1003.getDv()*ocs1003.getNalsu());
		inv2004.setChulgoQty(commonRepository.callFnDrgWonyoiTotSurang(ocs1003.getNalsu(), ocs1003.getSuryang(), ocs1003.getDv(), ocs1003.getDvTime()));
		
		inv2004Repository.save(inv2004);
		return inv2004;
	}

	private Inv4001 insertInv4001(String hospCode, String language, String userId, String remark){
		Inv4001 inv4001 = new Inv4001();
		List<Adm3200> admList = adm3200Repository.findByHospCodeUserId(hospCode, userId);
		String churiBuseo = CollectionUtils.isEmpty(admList) ? "" : admList.get(0).getDeptCode();
		Double churiSeq = CommonUtils.parseDouble(commonRepository.getNextVal("IPGO_SEQ"));
		Double pkInv4001 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4001_SEQ")); // refer INV4001NextSeqHandler
		List<String> listCodeName = inv0102Repository.getCodeNameByCodeAndCodeType(hospCode, language, "INV_EXPORT", "INV_PREFIX");
		String importCode = CollectionUtils.isEmpty(listCodeName) ? String.format("%.0f", churiSeq) : listCodeName.get(0) + String.format("%.0f", churiSeq);
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		String sTime = localDateFormat.format(new Date());
		
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
		inv4001.setChuriTime(sTime);
		inv4001.setRemark(remark);
		
		inv4001Repository.save(inv4001);
		return inv4001;
	}
    
	private Inv4002 insertInv4002(String hospCode, String userId, Double fkInv4001, Ocs1003 ocs1003, String jaeryoCode){
		Inv4002 inv4002 = new Inv4002();
		Double pkInv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
		
		inv4002.setPkinv4002(pkInv4002);
		inv4002.setLot("0");
		inv4002.setExpiredDate(DateUtil.toDate("9999/12/31", DateUtil.PATTERN_YYMMDD));
		
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setFkinv4001(fkInv4001);
		inv4002.setJaeryoCode(jaeryoCode);
		//inv4002.setIpgoQty(ocs1003.getSuryang()*ocs1003.getDv()*ocs1003.getNalsu());
		inv4002.setIpgoQty(commonRepository.callFnDrgWonyoiTotSurang(ocs1003.getNalsu(), ocs1003.getSuryang(), ocs1003.getDv(), ocs1003.getDvTime()));
		
		inv4002Repository.save(inv4002);
		return inv4002;
	}

}
