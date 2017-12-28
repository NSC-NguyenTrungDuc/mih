package nta.mss.misc.unit;

import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;

import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.ArgumentCaptor;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.powermock.core.classloader.annotations.PowerMockIgnore;
import org.powermock.core.classloader.annotations.PrepareForTest;
import org.powermock.modules.junit4.PowerMockRunner;
import org.powermock.reflect.Whitebox;

import nta.mss.entity.Department;
import nta.mss.entity.Doctor;
import nta.mss.entity.Hospital;
import nta.mss.entity.Patient;
import nta.mss.entity.Reservation;
import nta.mss.entity.Session;
import nta.mss.info.BookingInfo;
import nta.mss.repository.ReservationRepository;
import nta.mss.service.impl.BookingService;

/**
 * 
 * @author TungLT
 *
 */
@RunWith(PowerMockRunner.class)
@PrepareForTest({ BookingService.class })
@PowerMockIgnore({ "org.w3c.*", "javax.xml.*", "org.apache.xerces.*", "javax.xml.parsers.*", "org.xml.sax.*" })
public class BookingServiceTest {

	@Mock
	ReservationRepository reservationRepository;
	
	@InjectMocks
	BookingService bookingService = new BookingService();

	@Before
	public void setUp() {
		MockitoAnnotations.initMocks(this);
	}

	@Test
	public void testSaveReservationWithSessionIsNull() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(45);
		Session session = null;
		boolean isBackendBooking = true;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
	}
	@Test
	public void testSaveReservationWithSessionIsNotNull() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(45);
		Session session = new Session();
		session.setSessionId("dlasdjlasdlaskfpasfjasfjlasfjasjflasfjkasf");
		boolean isBackendBooking = true;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
	}
	
	@Test
	public void testSaveReservationWithPatientIconPathIsNull() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		bookingInfo.setPatientIconPath(null);
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(45);
		Session session = new Session();
		session.setSessionId("dsadasdasdasda14232323");
		boolean isBackendBooking = true;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
		Assert.assertEquals(Integer.valueOf(45), reservation.getValue().getReminderTime());
	}
	
	@Test
	public void testSaveReservationWithPatientIconPathIsNotNull() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		bookingInfo.setPatientIconPath("http://117.6.172.190:8180/phr_upload/514/896/Penguins-1478593917303.jpg");
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(15);
		Session session = new Session();
		session.setSessionId("dsadasdasdasda14232323");
		boolean isBackendBooking = true;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
		Assert.assertEquals(Integer.valueOf(15), reservation.getValue().getReminderTime());
	}
	
	@Test
	public void testSaveReservationWithIsBackendBooking() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		bookingInfo.setPatientIconPath("http://117.6.172.190:8180/phr_upload/514/896/Penguins-1478593917303.jpg");
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(10);
		Session session = new Session();
		session.setSessionId("dsadasdasdasda14232323");
		boolean isBackendBooking = true;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
		Assert.assertEquals(Integer.valueOf(10), reservation.getValue().getReminderTime());
	}
	
	@Test
	public void testSaveReservationWithIsNotBackendBooking() throws Exception {
		final String methodToTest = "createReservation";
		BookingInfo bookingInfo = new BookingInfo();
		bookingInfo.setDeptId(27205);
		bookingInfo.setDeptName("内科");
		bookingInfo.setDeptType(0);
		bookingInfo.setDoctorId(544);
		bookingInfo.setDoctorName("田中　太一");
		bookingInfo.setEmail("linh12345678pp@gmail.com");
		bookingInfo.setPatientDob("1978/05/03");
		bookingInfo.setPatientFurigana("さいと　さいと");
		bookingInfo.setReservationDate("20161110");
		bookingInfo.setUserId(173);
		bookingInfo.setReservationTime("2100");
		bookingInfo.setPatientIconPath("http://117.6.172.190:8180/phr_upload/514/896/Penguins-1478593917303.jpg");
		Doctor doctor = new Doctor();
		doctor.setDoctorId(544);
		doctor.setName("田中　太一");
		Patient patient = new Patient();
		Hospital hospital = new Hospital();
		hospital.setActiveFlg(1);
		hospital.setHospitalCode("519");
		hospital.setHospitalId(115);
		hospital.setHospitalName("テスト病院7");
		hospital.setHospitalParentId(1);
		hospital.setHospitalType(1);
		hospital.setIsUseMt(1);
		hospital.setIsUseSms(1);
		hospital.setLocale("ja");
		Department department = new Department();
		department.setDeptId(27205);
		bookingInfo.setReminderTime(60);
		Session session = new Session();
		session.setSessionId("dsadasdasdasda14232323");
		boolean isBackendBooking = false;
		ArgumentCaptor<Reservation> reservation = ArgumentCaptor.forClass(Reservation.class);
		Object[] parameters = new Object[]{bookingInfo, patient,session,isBackendBooking,doctor,department,hospital};
		Whitebox.invokeMethod(bookingService, methodToTest,parameters);
		
		verify(reservationRepository, times(1)).save(reservation.capture());
		Assert.assertEquals("テスト病院7", reservation.getValue().getHospital().getHospitalName());
		Assert.assertEquals("20161110", reservation.getValue().getReservationDate());
		Assert.assertEquals("2100", reservation.getValue().getReservationTime());
		Assert.assertEquals(Integer.valueOf(60), reservation.getValue().getReminderTime());
	}
	
}
