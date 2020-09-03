using Syncfusion.SfCarousel.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurryFit.Repository;
using FurryFit.ViewModels.Pets;
using FurryFit.Views.Forms;
using Syncfusion.XForms.AvatarView;
using Syncfusion.XForms.BadgeView;
using Syncfusion.XForms.Border;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using SelectionChangedEventArgs = Syncfusion.SfCarousel.XForms.SelectionChangedEventArgs;

namespace FurryFit.Views.Dashboard
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardContent : ContentPage
    {

        PetProfileViewModel item = new PetProfileViewModel();
        PetProfilesVM petProfiles = new PetProfilesVM();
        public DashboardContent()
        {
            InitializeComponent();
            //SfCarousel carousel = new SfCarousel()
            //{
            //    ItemWidth = 170,
            //    ItemHeight = 250
            //};

            //listView.ItemsSource = await App.Database.GetNotesAsync();
            carousel.BindingContext = petProfiles;
            carousel.ItemsSource = petProfiles.Pets;
            ObservableCollection<SfCarouselItem> carouselItems = new ObservableCollection<SfCarouselItem>();
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new SfBorder()
            //    {
            //        BorderColor = Color.Black,
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center,
            //        CornerRadius = 20,
            //        BorderWidth = 3,
            //        Content = new Image()
            //        {
            //            Source = "furryfitlogo.png",
            //            Aspect = Aspect.AspectFit
            //        }

            //    }

            //});
            
            carouselItems.Add(new SfCarouselItem()
            {
                ItemContent = new SfBadgeView()
                {
                    Padding = 0,
                    HeightRequest = 100,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    WidthRequest = 100,
                    Content = new SfAvatarView()
                    {
                        ContentType = ContentType.Default,
                        ImageSource = "furryfiticon.png",
                        Padding = 0,
                        BackgroundColor = Color.Beige,
                        BorderWidth = 4,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        CornerRadius = 50,
                        HeightRequest = 100,
                        WidthRequest = 100,
                    }

                }

            });
            carouselItems.Add(new SfCarouselItem()
            {
                ItemContent = new SfBadgeView()
                {
                    Padding = 0,
                    HeightRequest = 100,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    WidthRequest = 100,
                    Content =  new SfAvatarView()
                    {
                        ContentType = ContentType.Default,
                        ImageSource = "furryfiticon.png",
                        Padding = 0,
                        BackgroundColor = Color.Beige,
                        BorderWidth = 2,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        CornerRadius = 50,
                        HeightRequest = 100,
                        WidthRequest = 100,
                    }

                }

            });
            carouselItems.Add(new SfCarouselItem()
            {
                ItemContent = new SfBadgeView()
                {
                    Padding = 0,
                    HeightRequest = 100,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    WidthRequest = 100,
                    Content = new SfAvatarView()
                    {
                        ContentType = ContentType.Default,
                        ImageSource = "furryfiticon.png",
                        Padding = 13,
                        BackgroundColor = Color.Beige,
                        BorderWidth = 2,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        CornerRadius = 50,
                        HeightRequest = 100,
                        WidthRequest = 100,
                    }

                }

            });
            carouselItems.Add(new SfCarouselItem()
            {
                ItemContent = new SfBadgeView()
                {
                    Padding = 0,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Content = new SfAvatarView()
                    {
                        ContentType = ContentType.Initials,
                        ImageSource = "furryfiticon.png",
                        Padding = 13,
                        BackgroundColor = Color.Beige,
                        BorderWidth = 2,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        CornerRadius = 50,
                        HeightRequest = 100,
                        WidthRequest = 100,
                        AvatarName = "Add New Pet",
                        InitialsType = InitialsType.DoubleCharacter,
                        InitialsColor = Color.Black
                    },
                    BadgeSettings = new BadgeSetting()
                    {
                        BadgeIcon = BadgeIcon.Add,
                        BadgeAlignment = BadgeAlignment.Start,
                        BadgePosition = BadgePosition.BottomRight,
                        FontSize = 15,
                        StrokeWidth = 4,
                        TextPadding = 7,
                        Offset = new Point(-5,-10)

                        
                    }
                    

                }

            });
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new Image()
            //    {
            //        Source = "furryfitlogo.png",
            //        Aspect = Aspect.AspectFit
            //    }
            //}); 
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new Button()
            //    {
            //        Text = "ItemContent1",
            //        TextColor = Color.White,
            //        BackgroundColor = Color.FromHex("#7E6E6B"),
            //        FontSize = 12
            //    }
            //});
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new Label()
            //    {
            //        Text = "ItemContent2",
            //        BackgroundColor = Color.FromHex("#7E6E6B"),
            //        HorizontalTextAlignment = TextAlignment.Center,
            //        VerticalTextAlignment = TextAlignment.Center,
            //        FontSize = 12
            //    }
            //});
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new SfBadgeView()
            //    {
            //        Padding = 0,
            //        HeightRequest = 100,
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center,
            //        WidthRequest = 100,
            //        Content = new SfAvatarView()
            //        {
            //            ContentType = ContentType.Default,
            //            ImageSource = "furryfiticon.png",
            //            Padding = 13,
            //            BackgroundColor = Color.White,
            //            BorderWidth = 2,
            //            HorizontalOptions = LayoutOptions.Center,
            //            VerticalOptions = LayoutOptions.Center,
            //            AvatarShape = AvatarShape.Circle,
            //            HeightRequest = 100,
            //            WidthRequest = 100
            //        }

            //    }

            //}); 
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new SfBadgeView()
            //    {
            //        Padding = 0,
            //        HeightRequest = 100,
            //        HorizontalOptions = LayoutOptions.Center,
            //        VerticalOptions = LayoutOptions.Center,
            //        WidthRequest = 100,
            //        Content = new SfAvatarView()
            //        {
            //            ContentType = ContentType.Custom,
            //            ImageSource = "furryfiticon.png",
            //            Padding = 13,
            //            BackgroundColor = Color.White,
            //            BorderWidth = 2,
            //            HorizontalOptions = LayoutOptions.Center,
            //            VerticalOptions = LayoutOptions.Center,
            //            AvatarShape = AvatarShape.Circle,
            //            HeightRequest = 100,
            //            WidthRequest = 100
            //        }

            //    }

            //});


            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new Image()
            //    {
            //        Source = "furryfitlogo.png",
            //        Aspect = Aspect.AspectFit
            //    }
            //});
            //carouselItems.Add(new SfCarouselItem()
            //{
            //    ItemContent = new Image()
            //    {
            //        Source = "furryfitlogo.png",
            //        Aspect = Aspect.AspectFit
            //    }
            //});

            //carousel.ItemsSource = carouselItems;


            //carousel.ViewMode = ViewMode.Linear;
            //this.Content = carousel;
            //this.Content.BackgroundColor = Color.Wheat;
        }

        private void Carousel_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             item = (PetProfileViewModel)e.SelectedItem;
            //item.BackgroundColor=Color.DarkBlue;
            //SfBadgeView badgeView = (SfBadgeView) item.ItemContent;
            //SfAvatarView avatar = (SfAvatarView)badgeView.Content;
            

        }

        private async void SfButton6_OnClicked(object sender, EventArgs e)
        {
            item = petProfiles.Pets[carousel.SelectedIndex];
            await Navigation.PushModalAsync(new AdditionalInfoPage(item.Id.Value));
        }

        //private void TapGestureRecognizer_OnTapped1(object sender, EventArgs e)
        //{
        //    item = petProfiles.Pets[carousel.SelectedIndex];




        //    Navigation.PushModalAsync(new AddPetProfilePage(item));
        //}

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            item = petProfiles.Pets[carousel.SelectedIndex];




            Navigation.PushModalAsync(new AddPetProfilePage(item));
        }

        //private void AvatarView_OnTapped(object sender, EventArgs e)
        //{
        //    item = petProfiles.Pets[(sender as SfCarousel).SelectedIndex];




        //    Navigation.PushModalAsync(new AddPetProfilePage(item));
        //}
    }
}
