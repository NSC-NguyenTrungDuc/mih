package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0250;
import nta.med.core.domain.bas.Bas0253;
import nta.med.core.glossary.DataRowState;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0250Repository;
import nta.med.data.dao.medi.bas.Bas0253Repository;
import nta.med.service.ihis.proto.BassModelProto;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0250U00SaveLayoutRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

@Service
@Scope("prototype")
public class BAS0250U00SaveLayoutHandler
		extends ScreenHandler<BassServiceProto.BAS0250U00SaveLayoutRequest, SystemServiceProto.UpdateResponse> {

	private static final Log LOGGER = LogFactory.getLog(BAS0250U00SaveLayoutHandler.class);
	
	@Resource
	private Bas0250Repository bas0250Repository;
	
	@Resource
	private Bas0253Repository bas0253Repository;
	
	@Override
	@Transactional
	public UpdateResponse handle(Vertx vertx, String clientId, String sessionId, long contextId,
			BAS0250U00SaveLayoutRequest request) throws Exception {
		
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		String hospCode = getHospitalCode(vertx, sessionId);
		String userId = request.getUserId();
		
		List<BassModelProto.BAS0250U00GrdHoCodeListInfo> grdHoCode = request.getGrdHoCodeList();
		List<BassModelProto.BAS0250U00GrdBAS0253Info> grdBas0253 = request.getGrdBas0253List();
		
		// case 1
		if(!CollectionUtils.isEmpty(grdHoCode)){
			for (BassModelProto.BAS0250U00GrdHoCodeListInfo info : grdHoCode) {
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
					response = addBas0250(info, hospCode, userId);
				} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
					response = updateBas0250(info, hospCode, userId);
				} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
					response = deleteBas0250(info, hospCode, userId);
				}
				
				if(!response.getResult()){
					LOGGER.info(String.format("IUD BAS0250 fail, hosp_code = %s", hospCode));
					throw new ExecutionException(response.setResult(false).build());
				}
			}
		}
		
		// case 2
		if(!CollectionUtils.isEmpty(grdBas0253)){
			for (BassModelProto.BAS0250U00GrdBAS0253Info info : grdBas0253) {
				if(DataRowState.ADDED.getValue().equals(info.getDataRowState())){
					response = addBas0253(info, hospCode, userId);
				} else if(DataRowState.MODIFIED.getValue().equals(info.getDataRowState())){
					response = updateBas0253(info, hospCode, userId);
				} else if(DataRowState.DELETED.getValue().equals(info.getDataRowState())){
					response = deleteBas0253(info, hospCode, userId);
				}
			}
			
			if(!response.getResult()){
				LOGGER.info(String.format("IUD BAS0253 fail, hosp_code = %s", hospCode));
				throw new ExecutionException(response.setResult(false).build());
			}
		}
		
		response.setResult(true);
		return response.build();
	}
	
	private UpdateResponse.Builder addBas0250(BassModelProto.BAS0250U00GrdHoCodeListInfo info, String hospCode, String userId){
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		
		// check
		List<Bas0250> lstBas0250 = bas0250Repository.findByHoCodeHoDongStartDate(hospCode, info.getHoCode(), info.getHoDong(), info.getHoCodeYmd());
		if(!CollectionUtils.isEmpty(lstBas0250)){
			LOGGER.info(String.format("Check add bas0250 fail, msg = 11, hosp_code = %s, ho_code = %s, ho_dong = %s, HoCodeYmd = %s",
					hospCode, info.getHoCode(), info.getHoDong(), info.getHoCodeYmd()));
			
			response.setResult(false);
			response.setMsg("11 " + info.getHoDong());
			return response;
		}
		
		// update
		bas0250Repository.updateTableBas0250(hospCode, userId, info.getHoCodeYmd(), info.getHoCode(), info.getHoDong());
		
		// insert
		Date sysDate = new Date();
		Date startDate = DateUtil.toDate(info.getHoCodeYmd(),DateUtil.PATTERN_YYMMDD);
		Date endDate = DateUtil.toDate(info.getBulyongDate(),DateUtil.PATTERN_YYMMDD);
		Double hoTotalBed = CommonUtils.parseDouble(info.getHoTotalBed());
		Double hoUsedBed = CommonUtils.parseDouble(info.getHoUsedBed());
		Double hoSexMale = CommonUtils.parseDouble(info.getHoSexMale());
		Double hoSexFemail = CommonUtils.parseDouble(info.getHoSexFemale());
		Double hoSort = CommonUtils.parseDouble(info.getHoSort());
		Double reportTotalBed = CommonUtils.parseDouble(info.getReportTotalBed());
		
		Bas0250 bas0250 = new Bas0250();
		bas0250.setSysDate(sysDate);
		bas0250.setSysId(userId);
		bas0250.setUpdDate(sysDate);
		bas0250.setUpdId(userId);
		bas0250.setHospCode(hospCode);
		bas0250.setStartDate(startDate);
		bas0250.setHoCode(info.getHoCode());
		bas0250.setHoDong(info.getHoDong());
		bas0250.setHoGrade(info.getHoGrade());
		bas0250.setHoTotalBed(hoTotalBed);
		bas0250.setHoUsedBed(hoUsedBed);
		bas0250.setHoMainGwa(info.getHoMainGwa());
		bas0250.setHoSex(info.getHoSex());
		bas0250.setHoSexMail(hoSexMale);
		bas0250.setHoSexFemail(hoSexFemail);
		bas0250.setHoSpecialYn(info.getHoSpecialYn());
		bas0250.setHoStatus(info.getHoStatus());
		bas0250.setEndDate(endDate);
		bas0250.setHoGubun(info.getHoGubun());
		bas0250.setHoCodeName(info.getHoCodeName());
		bas0250.setHoSort(hoSort);
		bas0250.setReportTotalBed(reportTotalBed);
		bas0250.setDoubleHoYn(info.getDoubleHoYn());
		bas0250Repository.save(bas0250);
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder updateBas0250(BassModelProto.BAS0250U00GrdHoCodeListInfo info, String hospCode, String userId){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		List<Bas0250> lstBas0250 = bas0250Repository.findByHoCodeHoDongStartDate(hospCode, info.getHoCode(), info.getHoDong(), info.getHoCodeYmd());
		if(CollectionUtils.isEmpty(lstBas0250)){
			LOGGER.info(String.format("Check upd bas0250 fail, msg = 11, hosp_code = %s, ho_code = %s, ho_dong = %s, HoCodeYmd = %s",
					hospCode, info.getHoCode(), info.getHoDong(), info.getHoCodeYmd()));
			
			response.setResult(false);
			return response;
		}
		
		Bas0250 bas0250 = lstBas0250.get(0);
		Date sysDate = new Date();
		Date endDate = DateUtil.toDate(info.getBulyongDate(),DateUtil.PATTERN_YYMMDD);
		Double hoTotalBed = CommonUtils.parseDouble(info.getHoTotalBed());
		Double hoUsedBed = CommonUtils.parseDouble(info.getHoUsedBed());
		Double hoSexMale = CommonUtils.parseDouble(info.getHoSexMale());
		Double hoSexFemail = CommonUtils.parseDouble(info.getHoSexFemale());
		Double hoSort = CommonUtils.parseDouble(info.getHoSort());
		Double reportTotalBed = CommonUtils.parseDouble(info.getReportTotalBed());
		
		bas0250.setUpdDate(sysDate);
		bas0250.setUpdId(userId);
		bas0250.setHoGrade(info.getHoGrade());
		bas0250.setHoTotalBed(hoTotalBed);
		bas0250.setHoUsedBed(hoUsedBed);
		bas0250.setHoMainGwa(info.getHoMainGwa());
		bas0250.setHoSex(info.getHoSex());
		bas0250.setHoSexMail(hoSexMale);
		bas0250.setHoSexFemail(hoSexFemail);
		bas0250.setHoSpecialYn(info.getHoSpecialYn());
		bas0250.setHoStatus(info.getHoStatus());
		bas0250.setEndDate(endDate);
		bas0250.setHoGubun(info.getHoGubun());
		bas0250.setHoCodeName(info.getHoCodeName());
		bas0250.setHoSort(hoSort);
		bas0250.setReportTotalBed(reportTotalBed);
		bas0250.setDoubleHoYn(info.getDoubleHoYn());
		bas0250Repository.save(bas0250);
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder deleteBas0250(BassModelProto.BAS0250U00GrdHoCodeListInfo info, String hospCode, String userId){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		// update
		bas0250Repository.updateTableBas0250CaseDelete(hospCode, userId, info.getHoCodeYmd(), info.getHoCode(), info.getHoDong());
		
		// delete
		Integer rowDeleted = bas0250Repository.deleteByHospCodeHoCodeHoDongStartDate(hospCode, info.getHoCode(), info.getHoDong(), info.getHoCodeYmd());
		
		response.setResult(rowDeleted > 0);
		return response;
	}

	private UpdateResponse.Builder addBas0253(BassModelProto.BAS0250U00GrdBAS0253Info info, String hospCode, String userId){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		List<Bas0253> listBas0253 = bas0253Repository.findByHoDongHoCodeBedNoFromBedDate(hospCode, info.getHoDong(), info.getHoCode(), info.getBedNo(), info.getFromBedDate());
		if(!CollectionUtils.isEmpty(listBas0253)){
			LOGGER.info(String.format("Check add Bas0253 fail, hosp_code = %s, HoDong = %s, HoCode = %s, BedNo = %s, FromBedDate = %s",
					hospCode, info.getHoDong(), info.getHoCode(), info.getBedNo(), info.getFromBedDate()));
			
			response.setResult(false);
			response.setMsg("23 " + info.getBedNo());
			return response;
		}
		
		// update
		bas0253Repository.updateTableBas0253(hospCode, userId, info.getFromBedDate(), info.getHoCode(), info.getHoDong(), info.getBedNo());
		
		// insert
		Bas0253 bas0253 = new Bas0253();
		Date sysDate = new Date();
		Date fromBedDate = DateUtil.toDate(info.getFromBedDate(),DateUtil.PATTERN_YYMMDD);
		Date toBedDate = DateUtil.toDate(info.getToBedDate(),DateUtil.PATTERN_YYMMDD);
		
		bas0253.setSysDate(sysDate);
		bas0253.setSysId(userId);
		bas0253.setUpdDate(sysDate);
		bas0253.setUpdId(userId);
		bas0253.setHospCode(hospCode);
		bas0253.setHoCode(info.getHoCode());
		bas0253.setBedNo(info.getBedNo());
		bas0253.setFromBedDate(fromBedDate);
		bas0253.setToBedDate(toBedDate);
		bas0253.setBedStatus(info.getBedStatus());
		bas0253.setBedNoTel(info.getBedNoTel());
		bas0253.setHoDong(info.getHoDong());
		bas0253Repository.save(bas0253);
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder updateBas0253(BassModelProto.BAS0250U00GrdBAS0253Info info, String hospCode, String userId){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		List<Bas0253> listBas0253 = bas0253Repository.findByHoDongHoCodeBedNoFromBedDate(hospCode, info.getHoDong(), info.getHoCode(), info.getBedNo(), info.getFromBedDate());
		if(CollectionUtils.isEmpty(listBas0253)){
			LOGGER.info(String.format("Check upd Bas0253 fail, hosp_code = %s, HoDong = %s, HoCode = %s, BedNo = %s, FromBedDate = %s",
					hospCode, info.getHoDong(), info.getHoCode(), info.getBedNo(), info.getFromBedDate()));
			
			response.setResult(false);
			return response;
		}
		
		Bas0253 bas0253 = listBas0253.get(0);
		Date toBedDate = DateUtil.toDate(info.getToBedDate(),DateUtil.PATTERN_YYMMDD);
		
		bas0253.setUpdId(userId);
		bas0253.setUpdDate(new Date());
		bas0253.setToBedDate(toBedDate);
		bas0253.setBedStatus(info.getBedStatus());
		bas0253.setBedNoTel(info.getBedNoTel());
		bas0253Repository.save(bas0253);
		
		response.setResult(true);
		return response;
	}
	
	private UpdateResponse.Builder deleteBas0253(BassModelProto.BAS0250U00GrdBAS0253Info info, String hospCode, String userId){
		UpdateResponse.Builder response = UpdateResponse.newBuilder();
		
		// update
		bas0253Repository.updateTableBas0253CaseDelete(hospCode, userId, info.getFromBedDate(), info.getHoCode(), info.getHoDong(), info.getBedNo());
		
		// delete
		bas0253Repository.deleteByHospCodeHoCodeHoDongBedNoFromBedDate(hospCode, info.getHoCode(), info.getHoDong(), info.getBedNo(), info.getFromBedDate());
		
		response.setResult(true);
		return response;
	}
}
