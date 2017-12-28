package nta.med.service.ihis.handler.invs;

import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.lang.StringUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.config.Configuration;
import nta.med.core.domain.bas.Bas0001;
import nta.med.core.domain.inv.Inv4001;
import nta.med.core.domain.inv.Inv4002;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.bas.Bas0001Repository;
import nta.med.data.dao.medi.com.ComSeqRepository;
import nta.med.data.dao.medi.inv.Inv0102Repository;
import nta.med.data.dao.medi.inv.Inv4001Repository;
import nta.med.data.dao.medi.inv.Inv4002Repository;
import nta.med.service.ihis.proto.InvsModelProto;
import nta.med.service.ihis.proto.InvsModelProto.INV4001U00Grd4001Info;
import nta.med.service.ihis.proto.InvsModelProto.INV4001U00Grd4002Info;
import nta.med.service.ihis.proto.InvsServiceProto;
import nta.med.service.ihis.proto.InvsServiceProto.INV4001SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
@Transactional
public class INV4001SaveLayoutHandler extends ScreenHandler<InvsServiceProto.INV4001SaveLayoutRequest, SystemServiceProto.UpdateResponse>{

	@Resource
	private Inv4001Repository inv4001Repository;
	
	@Resource
	private Inv4002Repository inv4002Repository;
	
	@Resource
	private CommonRepository commonRepository;
	
	@Resource
	private ComSeqRepository comSeqRepository;
	
	@Resource
	private Inv0102Repository inv0102Repository;

	@Resource
	private Bas0001Repository bas0001Repository;
	
	@Resource
	private Configuration configuration;
	
	@Override
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			INV4001SaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		response.setResult(false);
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = getUserId(vertx, sessionId);
		
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
		
		SimpleDateFormat localDateFormat = new SimpleDateFormat("HHmm");
		int defaultTimeZone = configuration.getDefaultTimeZone() != null ? configuration.getDefaultTimeZone() : 9;		
		Date sysDate = CommonUtils.getLocalDateTime(defaultTimeZone, localTimeZone);
		String sTime = localDateFormat.format(sysDate);
		
		List<INV4001U00Grd4001Info> grd4001Infos = request.getInv4001List();
		List<INV4001U00Grd4002Info> grd4002Infos = request.getInv4002List();
		if(!CollectionUtils.isEmpty(grd4001Infos)){
			List<String> codeNames = inv0102Repository.getCodeNameByCodeAndCodeType(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), "INV_IMPORT", "INV_PREFIX");
			String preFixCode = codeNames.size() > 0 ? codeNames.get(0) : "";
			for (InvsModelProto.INV4001U00Grd4001Info item : grd4001Infos) {
				Double pkinv4001 = CommonUtils.parseDouble(item.getPkinv4001());
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {
					insertInv4001(item, hospCode, userId, preFixCode, sTime);
				}else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {
					Date churiDate = DateUtil.toDate(item.getChuriDate(), DateUtil.PATTERN_YYMMDD);
					inv4001Repository.updateINV4001(hospCode, pkinv4001, item.getRemark(), item.getImportCode(), churiDate);
				} else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {
					inv4001Repository.deleteINV4001(hospCode, pkinv4001);
				}
			}
		}
		if(!CollectionUtils.isEmpty(grd4002Infos)){
			for (InvsModelProto.INV4001U00Grd4002Info item : grd4002Infos) {
				Double fkinv4001 = CommonUtils.parseDouble(item.getFkinv4001());
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())) {

					String val = inv4002Repository.checkExists(hospCode, fkinv4001, item.getJaeryoCode());
					if(!StringUtils.isEmpty(val)){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					insertInv4002(item, hospCode, userId);
				}else if (item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())) {

					inv4002Repository.updateINV4002(hospCode, fkinv4001, item.getJaeryoCode(),
							CommonUtils.parseDouble(item.getIpgoQty()), CommonUtils.parseDouble(item.getIpgoDanga()), item.getRemark(),
							DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD),item.getLot(),
							DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD),
							userId);
				} else if (item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())) {

					inv4002Repository.deleteINV4002(hospCode, fkinv4001, item.getJaeryoCode());
				}
			}
		}
		response.setResult(true);
		return response.build();
	}
	
	private void insertInv4002(INV4001U00Grd4002Info item , String hospCode, String userId){
		Inv4002 inv4002 = new Inv4002();
		Double pkinv4002 = CommonUtils.parseDouble(commonRepository.getNextVal("INV4002_SEQ"));
		Date startDate = DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD);
		Date expiredDate = DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD);
		inv4002.setSysDate(new Date());
		inv4002.setSysId(userId);
		inv4002.setUpdDate(new Date());
		inv4002.setUpdId(userId);
		inv4002.setHospCode(hospCode);
		inv4002.setPkinv4002(pkinv4002);
		inv4002.setFkinv4001(CommonUtils.parseDouble(item.getFkinv4001()));
		inv4002.setJaeryoCode(item.getJaeryoCode());
		inv4002.setIpgoQty(CommonUtils.parseDouble(item.getIpgoQty()));
		inv4002.setIpgoDanga(CommonUtils.parseDouble(item.getIpgoDanga()));
		inv4002.setRemark(item.getRemark());
		inv4002.setStartDate(startDate);
		inv4002.setExpiredDate(expiredDate);
		inv4002.setLot(item.getLot());
		inv4002Repository.save(inv4002);
	}
	
	private void insertInv4001(INV4001U00Grd4001Info item , String hospCode, String userId, String preFixCode, String sTime){
		Inv4001 inv4001 = new Inv4001();
		Date churiDate = DateUtil.toDate(item.getChuriDate(), DateUtil.PATTERN_YYMMDD);
		String seqKey = item.getChuriDate().concat("-").concat(item.getChuriBuseo()).concat("-").concat(item.getIpgoType());
		Double churiSeq = comSeqRepository.getMaxSeq(hospCode, "INV4001", "SEQ", seqKey);
		String ipgoSeq = commonRepository.getNextVal("IPGO_SEQ");
		String importCode = preFixCode + ipgoSeq;
		inv4001.setSysDate(new Date());
		inv4001.setSysId(userId);
		inv4001.setUpdDate(new Date());
		inv4001.setUpdId(userId);
		inv4001.setHospCode(hospCode);
		inv4001.setPkinv4001(CommonUtils.parseDouble(item.getPkinv4001()));
		inv4001.setChuriDate(churiDate);
		inv4001.setChuriTime(sTime);
		inv4001.setImportCode(importCode);
		inv4001.setChuriBuseo(item.getChuriBuseo());
		inv4001.setIpgoType(item.getIpgoType());
		inv4001.setChuriSeq(churiSeq);
		inv4001.setJaeryoGubun(item.getJaeryoGubun());
		inv4001.setIpchulType(item.getIpchulType());
		inv4001.setInOutGubun(item.getInOutGubun());
		inv4001.setRemark(item.getRemark());
		inv4001Repository.save(inv4001);
	}

}
